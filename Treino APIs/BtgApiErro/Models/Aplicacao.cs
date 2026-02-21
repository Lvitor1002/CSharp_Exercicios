using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BtgApi.Models
{
    public class Aplicacao
    {
        public int AplicacaoID{ get; set; }
        public decimal Valor{ get; set; }
        public DateTime DataAplicacao{ get; set; }
        public int ProdutoFinanceiroID{ get; set; }
        public int ClienteID{ get; set; }

        public ProdutoFinanceiro ProdutoFinanceiro{ get; set; }
        public Cliente Cliente{ get; set; }

        //[Private] - usado para restringir a criação de objetos da classe Aplicacao fora da própria classe sem passar pelos parâmetros obrigatórios definidos no construtor público.
        //Bonus > O Entity Framework precisa de um construtor sem parâmetros para conseguir instanciar objetos ao materializar dados do banco.
        private Aplicacao() { }

        public Aplicacao(decimal valor, int produtoFinanceiroID, int clienteID)
        {
	        
            // Aplicação não pode ser igual ou menor que zero
            if(valor <= 0)
            {
                throw new ArgumentException("Valor da Aplicação não pode ser menor ou igual a zero!");
            }

            Valor = valor;
            ProdutoFinanceiroID = produtoFinanceiroID;
            ClienteID = clienteID;
            DataAplicacao = DateTime.Now;
        }

        public void RetirarSaldo(decimal valor)
        {
            Valor -= valor;
        }
    }
}
