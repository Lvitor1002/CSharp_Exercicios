
//Crie um algoritmo que leia um número e mostre o seu dobro, triplo e raiz quadrada.

using System;


namespace TREINO
{
    class Program
    {
        static void Main()
        {
            CalcularValor();
        }

        private static void CalcularValor()
        {
            double valor;
            while (true)
            {
                Console.Write("Entre com um valor real: ");
                string entrada = Console.ReadLine();
                if (!double.TryParse(entrada, out valor))
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido. Tente novamente. Digite um valor inteiro ou real.");
                    continue;
                }
                break;
            }
            Console.Clear();
            Console.WriteLine($"Dobro: {valor * 2}\nTriplo: {valor * 3}\nRaiz de {valor}: {Math.Sqrt(valor):f0}");
        }
    }
}

