namespace BtgApi.Models
{
    public class ProdutoFinanceiro
    {
        public int ProdutoFinanceiroID{ get; set; }
        public string NomeProdutoFinanceiro { get; set; } = string.Empty;
        public List<Aplicacao> ListaAplicacoes { get; set; } = new List<Aplicacao>();
        public List<Resgate> ListaResgates { get; set; } = new List<Resgate>();

        private ProdutoFinanceiro() { }

        public ProdutoFinanceiro(string nomeProdutoFinanceiro)
        {
            NomeProdutoFinanceiro = nomeProdutoFinanceiro;
        }


        //Como o ProdutoFinanceiro é a entidade que possui ListaAplicacoes, faz sentido que ela seja responsável por fornecer métodos para acessar/gerenciar seus próprios dados.
        //Centralizando assim a lógica de busca (evitando código duplicado).
        public Aplicacao BuscarAplicacaoPorID(int aplicacaoID)
        {
            var aplicacao = ListaAplicacoes.Find(a => a.AplicacaoID == aplicacaoID);

            if(aplicacao == null)
            {
                throw new InvalidOperationException($"Aplicação de id '{aplicacaoID}' não encontrada!");
            }
            return aplicacao;
        }
    }
}
