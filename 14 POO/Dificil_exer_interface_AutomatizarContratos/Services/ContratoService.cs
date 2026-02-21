using System;
using treino.Entities;
using treino.Services.Interfaces;

namespace treino.Services
{
    internal class ContratoService
    {
        private readonly IPayPalService _payPalService;

        public ContratoService(IPayPalService payPalService) => _payPalService = payPalService;

        //O processamento de um contrato consiste em gerar as parcelas a serem pagas para aquele contrato, com base no número de meses desejado.
        public void ProcessarContrato(Contrato contrato, int meses)
        {
            decimal valorBase = contrato.ValorTotalContrato;

            for (int m = 1; m <= meses; m++) 
            {
                DateTime dataVencimento = contrato.DataContrato.AddMonths(m);


                // Aplica juros simples (1% ao mês multiplicado pelo número do mês)
                decimal valorComJuros = valorBase + _payPalService.JurosSimples(valorBase, m);

                //Dividir pelo total de meses para obter o valor da parcela
                decimal valorParcela = valorComJuros / meses;

                // Aplicar taxa de 2% sobre o valor da parcela
                decimal valorFinal = valorParcela + _payPalService.TaxaPagamento(valorParcela);

                contrato.AddParcela(new Parcelas(dataVencimento, valorFinal));
            }
        }
    }
}
