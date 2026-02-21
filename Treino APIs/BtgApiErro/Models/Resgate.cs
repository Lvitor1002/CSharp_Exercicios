using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BtgApi.Models
{
    public class Resgate
    {
        public int ResgateID{ get; set; }
        public decimal ValorResgate{ get; set; }
        public decimal ImpostoRenda{ get; set; }
        public decimal ValorLiquidoIR{ get; set; }
        public DateTime DataResgate{ get; set; }


        public int ProdutoFinanceiroID { get; set; }
        public int ClienteID{ get; set; }


        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }
        public Cliente Cliente{ get; set; }


        //Motivo do private > O Entity Framework precisa de um construtor sem parâmetros para conseguir instanciar objetos ao materializar dados do banco.
        private Resgate() { }

        public Resgate(decimal valorResgate, Aplicacao aplicacao)
        {
            ValorResgate = valorResgate;
            DataResgate = DateTime.Now;

            //Um determinado produto financeiro recolhe imposto de renda apenas quando o cliente faz o seu resgate
            CalcularIR(aplicacao);
        }


        private void CalcularIR(Aplicacao aplicacao)
        {
            var lucro = ValorResgate - aplicacao.Valor;
            var duracaoAplicacao = (DataResgate - aplicacao.DataAplicacao).TotalDays / 365; //duração da aplicação em [anos]


            //O cálculo do IR=Imposto de Renda segue a seguinte l�gica abaixo:

		    // Até 1 ano de aplica��o: 22,5% sobre o lucro;
            if(duracaoAplicacao <= 1)
            {
                ImpostoRenda = lucro * 0.225m;
            } 
		    // 1 � 2 anos de aplica��o: 18,5% sobre o lucro;
            else if(duracaoAplicacao <= 2) 
            {
                ImpostoRenda = lucro * 0.185m;
            }
            // Acima de 2 anos de aplica��o: 15% sobre o lucro
            else
            {
                ImpostoRenda = lucro * 0.15m;
            }

            ValorLiquidoIR = ValorResgate - ImpostoRenda;
        }
    }
}
