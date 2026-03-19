
//Crie um algoritmo que leia um número e mostre o seu dobro, triplo e raiz quadrada.

using System;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static int LeituraDados()
        {
            int numero;
            while (true)
            {
                Console.Write("Entre com um número: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out numero) || numero <= 0){
                    Console.Clear();
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }
                break;
            }
            return numero;
        }

        private static int RetornarDobroValor(int valor)
            => valor * 2;

        private static int RetornarTriploValor(int valor)
            => valor * 2;

        private static double RetornarRaizValor(double valor)
            => Math.Sqrt(valor);

        private static void ExibirDados()
        {
            int numero = LeituraDados();
            Console.Clear();
            
            Console.WriteLine($@"
Dobro do {numero}: {RetornarDobroValor(numero)}
Triplo do {numero}: {RetornarTriploValor(numero)}
Raiz do {numero}: {RetornarRaizValor(Convert.ToDouble(numero)):F2}
");
        }

    }
}
