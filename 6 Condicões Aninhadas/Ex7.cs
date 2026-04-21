

/*
Desenvolva uma lógica que leia o: 
                                altura e 
                                altura 
de uma pessoa, calcule seu Índice de Massa Corporal (IMC) e mostre seu status, de acordo com a tabela abaixo:
                                                                        - IMC abaixo de 18,5: Abaixo do Peso
                                                                        - Entre 18,5 e 25: Peso Ideal
                                                                        - 25 até 30: Sobrepeso
                                                                        - 30 até 40: Obesidade
                                                                        - Acima de 40: Obesidade Mórbida

Fórmula: IMC = peso / (altura x altura)
*/

using System;
using System.Globalization;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static double RetornarPeso()
        {
            while (true)
            {
                Console.Write($"Entre com o peso: ");
                string entrada = Console.ReadLine().Trim();
                if (!double.TryParse(entrada, out double peso) || peso < 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com um valor inteiro ou real e maior que zero.");
                    continue;
                }
                return peso;
            }
        }
        private static double RetornarAltura()
        {
            while (true)
            {
                Console.Write($"Entre com a altura: ");
                string entrada = Console.ReadLine().Trim();
                if (!double.TryParse(entrada, NumberStyles.Any, CultureInfo.InvariantCulture, out double altura) || altura < 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Entre com um valor inteiro ou real e maior que zero.");
                    continue;
                }
                return altura;
            }
        }

        private static double RetornarIMC(double peso, double altura)
            => peso / Math.Pow(altura, 2);

        private static void ExibirDados()
        {
            double imc = RetornarIMC(RetornarPeso(), RetornarAltura());

            Console.Clear();
            Console.WriteLine(imc < 18.5 ? $"IMC de {imc:F2}: Abaixo do Peso.\n" 
                            : imc >= 18.5 && imc < 25 ? $"IMC de {imc:F2}: Peso Ideal.\n"
                            : imc >= 25 && imc < 30 ? $"IMC de {imc:F2}: Sobrepeso.\n"
                            : imc >= 30 && imc < 40 ? $"IMC de {imc:F2}: Obesidade.\n"
                            : $"IMC de {imc:F2}: Obesidade Mórbida.\n");
        }
    }
}
