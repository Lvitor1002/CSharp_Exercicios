
using treino.Services.Interfaces;

namespace treino.Services
{
    internal class PayPalService : IPayPalService
    {
        //Por enquanto, o serviço contratado pela empresa é o do Paypal, que aplica;
        //                                                            juros simples de 1% > a cada parcela,
        //                                                            taxa de pagamento de 2%.
        
        private const decimal _juros = 1 / 100m; //juros simples de 1%

        private const decimal _taxa = 2 / 100m; //taxa de pagamento de 2%.

        public decimal JurosSimples(decimal valor, int numeroParcela)=> valor * _juros * numeroParcela;

        public decimal TaxaPagamento(decimal valor)=> valor * _taxa;
    }
}
