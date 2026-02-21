

/*
Uma empresa deseja automatizar o processamento de seus contratos. 

O processamento de um contrato consiste em gerar as parcelas a serem pagas para aquele contrato, com base no número de meses desejado.

A empresa utiliza um serviço de pagamento online para realizar o pagamento das parcelas.

Os serviços de pagamento online tipicamente cobram um juro mensal, bem como uma taxa por pagamento. 

Por enquanto, o serviço contratado pela empresa é o do Paypal, que aplica;
                                                                    juros simples de 1% a cada parcela,
                                                                    taxa de pagamento de 2%.

Fazer um programa para ler os dados de um contrato; 
                                                    número do contrato, 
                                                    data do contrato,
                                                    valor total do contrato. 

Em seguida, o programa deve ler; 
                                número de meses para parcelamento do contrato

e gerar os registros de parcelas a serem pagas (data e valor), 
sendo; 
        a primeira parcela a ser paga um mês após a data do contrato, 
        a segunda parcela dois meses após o contrato 
e assim por diante. 

Mostrar os dados das parcelas na tela ao final.
*/

using System;
using System.Globalization;
using treino.Entities;
using treino.Services;
using treino.Services.Interfaces;

namespace treino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LeituraDados();
        }

        public static void LeituraDados()
        {
            int id, meses;
            decimal valorTotalContrato;



            while (true)
            {
                Console.Write("Entre com o número do contrato: ");
                string contratoID = Console.ReadLine().Trim();
                if (!int.TryParse(contratoID, out id) || id < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro'");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Entre com o valor do contrato: ");
                string valorC = Console.ReadLine().Trim();
                if (!decimal.TryParse(valorC, out valorTotalContrato) || valorTotalContrato <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' maior que 0.");
                    continue;
                }
                break;
            }

            Contrato contrato = new Contrato(i, valorTotalContrato);

            while (true)
            {
                Console.Write("Em quantos meses o contrato será parcelado: ");
                string qtdM = Console.ReadLine().Trim();
                if (!int.TryParse(qtdM, out meses) || meses < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior ou igual à 0.");
                    continue;
                }
                break;
            }

            IPayPalService payPalService = new PayPalService();
            ContratoService contratoService = new ContratoService(payPalService);

            contratoService.ProcessarContrato(contrato, meses);

            int soma = 0;
            Console.Clear();

            Console.WriteLine($"\n\t Dados da Parcela\n");
            foreach (var c in contrato.ListaParcelas)
            {
                soma += 1;
                Console.Write($"{soma}ª -{c.ToString()}");
            }
            Console.WriteLine(contrato.ToString());

        }
    }
}
