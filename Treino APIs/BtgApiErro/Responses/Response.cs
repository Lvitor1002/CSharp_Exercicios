namespace BtgApi.Responses
{
    public class Response
    {
        public record AplicacaoDTO(
            int ID,
            decimal Valor,
            DateTime DataAplicacao
            );


        public record ResgateDTO(
            int ID,
            decimal Valor,
            DateTime DataResgate,
            decimal ImpostoRenda,
            decimal ValorLiquidoIR
            );


        public record DetalhesProdutoFinanceiroDTO(
            int ID,
            string Nome,
            List<AplicacaoDTO> ListaAplicacaoDTO,
            List<ResgateDTO> ListaResgateDTO
            );
    }
}
