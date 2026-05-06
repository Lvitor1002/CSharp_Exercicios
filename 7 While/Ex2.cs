


/*
        Crie um programa que leia dois _valores e mostre um menu na tela:
        [ 1 ] somar
        [ 2 ] multiplicar
        [ 3 ] maior
        [ 4 ] novos números
        [ 5 ] sair do programa
        Seu programa deverá realizar a operação solicitada em cada caso.
*/


using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {
        private static List<double> _listaValores = new List<double>();

        private static void Main(string[] args)
            => ExibirDados();
        
        private static void PopularDoisValoresArray()
        {
            for(int i = 0; i < 2; i++)
            {
                Console.Clear();
                while (true)
                {
                    Console.Write($"Entre com o {i+1}ª valor: ");
                    string entrada = Console.ReadLine().Trim();
                    if(!double.TryParse(entrada, out double valor) || valor < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número maior que zero.");
                        continue;
                    }
                    _listaValores.Add(valor);
                    break;
                }
            }
            Console.Clear();
        }

        private static void ExibirMenu()
            =>Console.Write(@"
Escolha uma das opções abaixo:
                            [ 1 ] somar
                            [ 2 ] multiplicar
                            [ 3 ] maior
                            [ 4 ] novos números
                            [ 5 ] sair do programa
 "); 

        private static void ProcessarOperacoes()
        {
            while (true)
            {
                int numero;

                ExibirMenu();
                while (true)
                {
                    string entrada = Console.ReadLine().Trim();
                    if(!int.TryParse(entrada, out numero) || numero < 1 || numero > 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número de 1 à 5.");
                        continue;
                    }
                    break;
                }

                Console.Clear();
            
                switch (numero)
                {                
                    case 1:
                        Console.WriteLine($"Soma dos valores: {RetornarSomaValores()}");
                        break;
                    case 2:
                        Console.WriteLine($"Multiplicação dos valores: {RetornarMultiplicacaoValores()}");
                        break;
                    case 3:
                        Console.WriteLine($"Maior dos valores: {RetornarMaiorValor()}");
                        break;
                    case 4:
                        Console.WriteLine($"Valores atuais: {string.Join(", ",_listaValores)}.");
                        AdicionarMaisValores();
                        break;
                    case 5:
                        Console.WriteLine($"Saindo..");
                        return;
                }
            }
        }

        private static double RetornarSomaValores()
            =>_listaValores.Sum();

        private static double RetornarMaiorValor()
            =>_listaValores.Max();
        
        private static void AdicionarMaisValores()
        {
            while (true)
            {
                Console.Write("Entre com mais valores: ");
                string entrada = Console.ReadLine().Trim();
                if (!double.TryParse(entrada, out double valor) || valor < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número inteiro ou real maior ou igual a zero.");
                    continue;
                }
                _listaValores.Add(valor);
                break;
            }
            Console.Clear();
            Console.WriteLine($"Valores atuais: {string.Join(", ", _listaValores)}.");
        }

                
        // acc = acumulador(resultado parcial)
        // x = valor atual do array
        // -> A cada passo ele faz: acc = acc * x;
        private static double RetornarMultiplicacaoValores()
            => _listaValores.Aggregate((acc, x) => acc * x); 
                
        
        private static void ExibirDados()
        {
            PopularDoisValoresArray();
            ProcessarOperacoes();
        }
    }
}
