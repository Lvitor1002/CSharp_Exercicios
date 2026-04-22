

/*
Elabore um programa que calcule o valor a ser pago por um produto, considerando o seu preço normal e condição de pagamento:
                                                                                - à vista dinheiro/cheque: 10% de desconto
                                                                                - à vista no cartão: 5% de desconto
                                                                                - em até 2x no cartão: preço formal
                                                                                - 3x ou mais no cartão: 20% de juros
                                                                                */

using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static double RetornarValorProduto()
        {
            while (true)
            {
                Console.Write("Digite o valor do produto: ");
                string entrada = Console.ReadLine().Trim();
                if(!double.TryParse(entrada, out double valorProduto) || valorProduto < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Tente novamente.");
                    continue;
                }
                return valorProduto;
            }
        }

        private static int RetornarQuantidadeParcelas()
        {
            while (true)
            {
                var opcoesEntradas = new string[] { "s", "n" };

                Console.Write("Deseja realizar o parcelamento? [S/N] ");
                string entrada = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrEmpty(entrada) || !opcoesEntradas.Contains(entrada))
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Tente novamente digitando apenas 's' ou 'n'.");
                    continue;
                }
                if(entrada == "n")
                    return 0;
                break;
            }
            while (true)
            {
                Console.Write("Digite a quantidade de parcelas, de 3 à 10: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out int quantidadeParcelas) || quantidadeParcelas < 3 || quantidadeParcelas > 10)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Tente novamente.");
                    continue;
                }
                return quantidadeParcelas;
            }
        }

        private static void MenuCondicaoPagamento()
            => Console.WriteLine($@"
Escolha a condição de pagamento:

1 - à vista dinheiro/cheque: 10% de desconto
2 - à vista no cartão: 5% de desconto
3 - em até 2x no cartão: preço formal
4 - 3x ou mais no cartão: 20% de juros
");

        private static string RetornarCondicaoPagamento(double valorProduto, int quantidadeParcelas = 0)
        {
            Console.Clear();
            MenuCondicaoPagamento();
            int opcao;
            while (true)
            {
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out opcao) || opcao < 1 || opcao > 4)
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }
                break;
            }
            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    return $"Produto de {valorProduto:C2} reais, à vista, passou a ter 10% de desconto, custando agora {valorProduto * 0.9:C2}\n";
                case 2:
                    Console.Clear();
                    return $"Produto de {valorProduto:C2} reais, à vista no cartão, passou a ter 5% de desconto, custando agora {valorProduto * 0.95:C2}\n";
                case 3:
                    Console.Clear();
                    return $"Produto de {valorProduto:C2} reais, em 2x de {valorProduto/2:C2} reais\n";
                           
                case 4:
                    Console.Clear();
                    return quantidadeParcelas > 0 
                            ? $"Produto de {valorProduto:C2} reais, em {quantidadeParcelas}x, passou a ter 20% de juros.\nTotal de {valorProduto * 1.2:C2}\n{quantidadeParcelas}x de {(valorProduto * 1.2)/quantidadeParcelas:C2}\n"
                            : $"Produto de {valorProduto:C2} reais, não tem valor definido para quantidade de parcelas.\n";
            }
            return string.Empty;
        }
        
        private static void ExibirDados()
            =>Console.WriteLine(RetornarCondicaoPagamento(RetornarValorProduto(), RetornarQuantidadeParcelas()));
    }
}
