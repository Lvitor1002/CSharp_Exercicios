using BtgApi.Data;
using BtgApi.Models;
using BtgApi.Requests;
using BtgApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static BtgApi.Responses.Response;

namespace BtgApi.Services
{
    public class AligotaServices : IAligotaServices
    {
        private readonly BTGDB _db;
        public AligotaServices(BTGDB db)
        {
            _db = db;
        }


        public async Task<AplicacaoDTO> Aplicar(Request request)
        {
            if(request.Valor <= 0)
            {
                throw new ArgumentException("O valor da aplicação deve ser maior que 0!");
            }

            //Trazer todas as aplicações de clientes
            var clientes = await _db.Clientes // Acessa a tabela Clientes do contexto do EF Core
                .Include(x => x.ListaAplicacoes) // Carrega relacionamentos: Traz os registros relacionados da propriedade de navegação ListaAplicacoes
                .FirstOrDefaultAsync(x => x.ClienteID == request.ClienteID); // Método assíncrono que busca o primeiro registro que atende à condição ou null se não existir.

            if (clientes == null)
            {
                throw new ArgumentException("Cliente não foi encontrado!");
            }

            var produtoFinanceiro = await _db.ProdutosFinanceiros
                .FindAsync(request.CodeProdutoFinanceiro); //buscar uma entidade pela sua chave primária de forma assíncrona.

            if (produtoFinanceiro == null)
            {
                throw new ArgumentException("Produto financeiro não foi encontrado!");
            }


            //SELECT no banco para buscar os itens relacionados.
            await _db
                .Entry(produtoFinanceiro)
                .Collection(x => x.ListaAplicacoes)
                .LoadAsync();

            var aplicacao = new Aplicacao(request.Valor,request.CodeProdutoFinanceiro,request.ClienteID);

            produtoFinanceiro.ListaAplicacoes.Add(aplicacao);

            clientes.ListaAplicacoes.Add(aplicacao);
            
            await _db.SaveChangesAsync();

            var aplicacaoDTO = new AplicacaoDTO(
                aplicacao.AplicacaoID,
                aplicacao.Valor,
                aplicacao.DataAplicacao
                );
            
            return aplicacaoDTO;
        }

        public async Task<List<DetalhesProdutoFinanceiroDTO>> Listar()
        {
            var produtosFinanceiros = await _db.ProdutosFinanceiros
                .Include(x => x.ListaAplicacoes)
                .Include(x => x.ListaResgates)
                .ToListAsync();

            var produtosFinanceirosDTO = produtosFinanceiros.Select(x=>x.MapearDTO()).ToList();
            return produtosFinanceirosDTO;
        }

        public async Task<ResgateDTO> Resgate(Request request)
        {
            if (request.Valor <= 0)
            {
                throw new ArgumentException("O valor de Resgate deve ser maior que 0!");
            }

            //Trazer todas as aplicações de clientes
            var cliente = await _db.Clientes
                .Include(x => x.ListaResgates)
                .Include(x => x.ListaAplicacoes)
                .FirstOrDefaultAsync(x => x.ClienteID == request.ClienteID);

            if (cliente == null)
            {
                throw new ArgumentException("Cliente não foi encontrado!");
            }

            var produtoFinanceiro = await _db.ProdutosFinanceiros.FindAsync(request.CodeProdutoFinanceiro);

            if (produtoFinanceiro == null)
            {
                throw new ArgumentException("Produto financeiro não foi encontrado!");
            }

            await _db
                .Entry(produtoFinanceiro)
                .Collection(x => x.ListaAplicacoes)
                .LoadAsync();

            var aplicacao = produtoFinanceiro.BuscarAplicacaoPorID(request.AplicacaoID);

            if (aplicacao.Valor < request.Valor)
            {
                throw new ArgumentException("O valor do resgate não pode ser maior que o valor da aplicação!");
            }

            aplicacao.RetirarSaldo(request.Valor);

            var resgate = new Resgate(request.Valor, aplicacao);

            resgate.ClienteID = request.ClienteID;
            resgate.ProdutoFinanceiroID = request.CodeProdutoFinanceiro;

            _db.ProdutosFinanceiros.Update(produtoFinanceiro);

            _db.Resgates.Add(resgate);

            await _db.SaveChangesAsync();

            return new ResgateDTO(
                resgate.ClienteID,
                resgate.ValorResgate, //<- Atenção, pode ser (request)
                resgate.DataResgate,
                resgate.ImpostoRenda,
                resgate.ValorLiquidoIR
                );
        }
    }
}
