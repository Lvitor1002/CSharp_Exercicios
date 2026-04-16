


/*
    Crie um programa que leia duas notas de um aluno e calcule sua média, 
    mostrando uma mensagem no final, de acordo com a média atingida:
    - Média abaixo de 5.0: REPROVADO
    - Média entre 5.0 e 6.9: RECUPERAÇÃO
    - Média 7.0 ou superior: APROVADO
*/

using System;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static double[] RetornarArrayNotasAlunos()
        {
            var notas = new double[2];

            for(int i = 0; i< notas.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Entre com a {i+1}ª nota do aluno entre 0 à 10: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!double.TryParse(entrada, out double nota) || nota < 0 || nota > 10)
                    {
                        Console.Clear();
                        Console.WriteLine($"Entrada inválida. Digite uma nota entre 0 e 10.");
                        continue;
                    }
                    notas[i] = nota;
                    break;
                }
            }
            Console.Clear();
            return notas;
        }

        private static double RetornarMediaNotasAlunos(double[] notas)
            => notas.Average();

        private static string RetornarResultadoBoletimAluno(double media)
            => media >= 5 && media <= 6.9 ? $"Media {media}. Aluno em recuperação.\n" 
                : media >= 7 ? $"Media {media}. Aluno em Aprovado.\n" 
                : $"Media {media}. Aluno reprovado.\n";

        private static void ExibirDados()
            => Console.WriteLine(RetornarResultadoBoletimAluno(RetornarMediaNotasAlunos(RetornarArrayNotasAlunos())));
    }
}
