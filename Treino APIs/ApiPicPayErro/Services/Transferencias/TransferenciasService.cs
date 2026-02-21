using BackEndPicPay.Models;
using BackEndPicPay.Models.DTOs;
using BackEndPicPay.Models.Enum;
using BackEndPicPay.Models.Requests;
using BackEndPicPay.Models.Responses;
using BackEndPicPay.Repository.Interfaces;
using BackEndPicPay.Services.Autorizador;
using BackEndPicPay.Services.Notificacao;
using Microsoft.EntityFrameworkCore.Storage;

namespace BackEndPicPay.Services.Transferencias
{
    public class TransferenciasService : ITransferenciasService
    {
        private readonly ITransferenciaRepository _transacaoRepository;
        private readonly ICarteiraRepository _carteiraRepository;

        private readonly IAutorizadorService _autorizadorService;
        private readonly INotificacaoService _notificacaoService;

        public TransferenciasService(
            ITransferenciaRepository transacaoRepository,
            ICarteiraRepository carteiraRepository,
            IAutorizadorService autorizadorService,
            INotificacaoService notificacaoService
        )
        {
            _transacaoRepository = transacaoRepository;
            _carteiraRepository = carteiraRepository;
            _autorizadorService = autorizadorService;
            _notificacaoService = notificacaoService;
        }

        public async Task<Result<TransferenciaDto>> Executar(TransferenciaRequest request)
        {
            if(!await _autorizadorService.Autorizar())
            {
                return Result<TransferenciaDto>.FalhaResult("Não autorizado");
            }

            var pagador = await _carteiraRepository.BuscarPorId(request.EnviarId);
            
            var recebedor = await _carteiraRepository.BuscarPorId(request.ReceberId);

            if(pagador is null || recebedor is null)
            {
                return Result<TransferenciaDto>.FalhaResult("Nenhuma Carteira encontrada");
            }
            if(pagador.SaldoConta < request.Valor || pagador.SaldoConta == 0)
            {
                return Result<TransferenciaDto>.FalhaResult("Saldo Insuficiente");
            }
            if(pagador.Tipo == TipoUsuario.Usuario)
            {
                return Result<TransferenciaDto>.FalhaResult("Lojista não pode efetuar transferencia");
            }

            pagador.DebitarSaldo(request.Valor);
            recebedor.CreditarSaldo(request.Valor);

            var transferencia = new Transferencia(pagador.IdCarteira, recebedor.IdCarteira, request.Valor);

            using (var transferenciaScope = await _transacaoRepository.IniciarTransacao())
            {
                try
                {
                    var atualizarTarefas = new List<Task>
                    {
                        _carteiraRepository.AtualizarCarteira(pagador),
                        _carteiraRepository.AtualizarCarteira(recebedor),
                        _transacaoRepository.AdicionarTransferencia(transferencia)
                    };

                    await Task.WhenAll(atualizarTarefas);
                    
                    await _carteiraRepository.CommitAsync();
                    await _transacaoRepository.CommitAsync();
                    await transferenciaScope.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transferenciaScope.RollbackAsync();
                    return Result<TransferenciaDto>.FalhaResult("Erro ao realizar a transferência: " + ex.Message);
                }
            }

            await _notificacaoService.EnviarNotificacao();
            return Result<TransferenciaDto>.SucessoResult(transferencia.ToTransferenciaDto(transferencia));
        }

        private async Task CommitTransacao(IDbContextTransaction transacao)
        {
            await _transacaoRepository.CommitAsync();
            await transacao.CommitAsync();
        }

        private async Task RollbackTransacao(IDbContextTransaction transacao)
        {
            await transacao.RollbackAsync();
        }

    }
}
