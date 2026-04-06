

/*
    Desenvolva um programa que leia o nome, idade e sexo de 4 pessoas. 
    No final do programa, mostre: a média de idade do grupo, 
    qual é o nome do homem mais velho e quantas mulheres têm menos de 20 anos.
*/


using System;
using System.Globalization;
using System.Linq;

namespace Fundamentos
{
    public class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static Pessoa[] RetornarArrayPessoas()
        {
            var pessoas = new Pessoa[4];
            int idade;
            string nome, sexo;

            for (int i = 0; i < pessoas.Length; i++)
            {
                Console.Clear();
                Console.WriteLine($"\t      {i + 1}ª Pessoa");
                while (true)
                {
                    Console.Write($"Entre com o nome: ");
                    nome = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c=>char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine($"Entrada inválida.");
                        continue;
                    }
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }

                while (true)
                {
                    Console.Write($"Entre com a idade: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out idade))
                    {
                        Console.Clear();
                        Console.WriteLine($"Entrada inválida.");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.Write($"Entre com o sexo: [M/F] - ");
                    sexo = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(sexo) || !sexo.All(c => char.IsLetter(c) || c == ' ') || (!sexo.Contains('m') && !sexo.Contains('f'))) //"Se o campo sexo estiver vazio ou tiver caracteres inválidos (números, símbolos, etc.), então execute o bloco do if."
                    {
                        Console.Clear();
                        Console.WriteLine($"Entrada inválida. Sexo deve ser 'M' ou 'F'");
                        continue;
                    }
                    break;
                }
                pessoas[i] = new Pessoa(nome, idade, sexo);
            }
            return pessoas;
        }

        private static double RetornarMediaIdades(Pessoa[] pessoas)
            => pessoas.Average(p => p.Idade);

        private static string RetornarNomeHomemMaisVelho(Pessoa[] pessoas)
        {
            var homem = pessoas.Where(p => p.Sexo == "m").OrderByDescending(p => p.Idade).FirstOrDefault();

            return homem != null ? $"{homem.Nome} com {homem.Idade} anos" : "Não há homens cadastrados";
        }

        private static int RetornarQuantidadeMulheresMenosVinte(Pessoa[] pessoas)
            => pessoas.Count(p => p.Sexo == "f" && p.Idade < 20) ;

        private static void ExibirDados()
        {
            var pessoas = RetornarArrayPessoas();

            Console.Clear();
            Console.WriteLine($@"
-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
Média das idades: {RetornarMediaIdades(pessoas):F2}
Nome do homem mais velho: {RetornarNomeHomemMaisVelho(pessoas)}
Quantidade de mulheres com menos de 20 anos: {RetornarQuantidadeMulheresMenosVinte(pessoas)} mulheres
");

            Console.WriteLine("Todas as pessoas");
            foreach (var pessoa in pessoas)
                Console.WriteLine($@"
Nome:{pessoa.Nome}
Sexo:{pessoa.Sexo}
Idade:{pessoa.Idade}
-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
");
        }
    }
}
