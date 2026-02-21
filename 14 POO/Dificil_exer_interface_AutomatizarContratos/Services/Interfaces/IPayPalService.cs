

namespace treino.Services.Interfaces
{
    internal interface IPayPalService
    {
        //Por enquanto, o serviço contratado pela empresa é o do Paypal, que aplica;
        //                                                            juros simples de 1% > a cada parcela,
        //                                                            taxa de pagamento de 2%.

        decimal JurosSimples(decimal valor, int numeroParcela);
        decimal TaxaPagamento(decimal valor);
    }
}
