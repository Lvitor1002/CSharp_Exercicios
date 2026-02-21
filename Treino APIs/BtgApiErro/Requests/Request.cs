namespace BtgApi.Requests
{
    public class Request
    {
        public int CodeProdutoFinanceiro { get; set; }
        public int AplicacaoID{ get; set; }
        public decimal Valor{ get; set; }
        public int ClienteID{ get; set; }
        public DateTime Data{ get; set; }

        public Request(int aplicacaoID, decimal valor, DateTime data)
        {
            AplicacaoID = aplicacaoID;
            Valor = valor;
            Data = data;
        }
    }
}
