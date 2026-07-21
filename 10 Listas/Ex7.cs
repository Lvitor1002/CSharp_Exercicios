
/*
    Matriz 3×3

    Faça um programa que leia os valores para prrencher uma matriz inteira de 3 linhas por 3 colunas.

    Após o preenchimento da matriz, o programa deverá:
                                    Calcular e exibir a soma de todos os valores pares presentes na matriz.
                                    Calcular e exibir a soma dos valores da terceira coluna.
                                    Encontrar e exibir o maior valor da segunda linha.
                                    Exibir a matriz preenchida em formato de tabela.
*/


using System;
using System.Linq;

namespace Fundamentos
{
    public static class Program
    {

        private static void Main(string[] args)
            => ExibirDados();


        private static int[,] RetornarMatriz()
        {
            var matriz = new int[3,3];

            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                { 
                    Console.Clear();
                    while (true)
                    {
                        Console.Write($"Digite o [{linha + 1}ª Linha, {coluna + 1} Coluna]ª Número: ");
                        string entrada = Console.ReadLine().Trim();
                        if(!int.TryParse(entrada, out int numero) || numero < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Digite um número 'inteiro' positivo.");
                            continue;
                        }
                        matriz[linha, coluna] = numero;
                        break;
                    }
                }
            }
            Console.Clear();
            return matriz;
        }

        private static int RetornarSomatorioTotalMatriz(int[,] matriz)
            => matriz.Cast<int>().Where(x => x % 2 == 0).Sum();


        private static int RetornarSomatorioTerceiraColunaMatriz(int[,] matriz)
            => Enumerable.Range(0, 3).Select(linha => matriz[linha, 2]).Sum();


        private static int RetornarMaiorValorSegundaLinhaMatriz(int[,] matriz)
            => Enumerable.Range(0, 3).Select(coluna => matriz[1, coluna]).Max();


        private static void ExibirDados()
        {
            var matriz = RetornarMatriz();
            

            //Calcular e exibir a soma de todos os valores pares presentes na matriz.
            Console.WriteLine($"Soma de todos os valores pares da matriz: {RetornarSomatorioTotalMatriz(matriz)}\n");


            //Calcular e exibir a soma dos valores da terceira coluna.
            Console.WriteLine($"Soma de todos os valores da tercera coluna da matriz: {RetornarSomatorioTerceiraColunaMatriz(matriz)}\n");


            //Encontrar e exibir o maior valor da segunda linha.
            Console.WriteLine($"Maior valor da segunda linha da matriz: {RetornarMaiorValorSegundaLinhaMatriz(matriz)}\n");


            // Exibir a matriz preenchida em formato de tabela.
            Console.WriteLine("Matriz 3x3 preenchida:\n");
            for (int linha = 0; linha < 3; linha++)
            {
                Console.Write("|");
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    Console.Write($"{matriz[linha, coluna],3}  | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
        }
    }
}
