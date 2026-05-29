

/*
    Crie um programa que leia a nome, idade e o sexo de várias pessoas. 
    A cada pessoa cadastrada, o programa deverá perguntar se o usuário quer ou não continuar. 
    No final, mostre:
    A) quantas pessoas tem mais de 18 anos.
    B) quantos homens foram cadastrados.
    C) quantas mulheres tem menos de 20 anos. 
*/


using System;
using System.Collections.Generic;
using System.Linq;


namespace Fundamentos
{
    public class Pessoa
    {
        public string Nome{ get; set; }
        public string Sexo{ get; set; }
        public int Idade{ get; set; }

        public Pessoa(string nome, string sexo, int idade)
        {
            Nome = nome;
            Sexo = sexo;
            Idade = idade;
        }

        public override string ToString()
            => $@"
Nome: {Nome}
Sexo: {Sexo}
Idade: {Idade}
";
    }

    public static class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static List<Pessoa> RetornarListaPessoas()
        {
            var listaPessoas = new List<Pessoa>();
            int idade, quantidadePessoa = 0;
            string nome, sexo;

            while (true)
            {
                Console.Write("Entre com a quantidade de pessoas a ser cadastradas: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out quantidadePessoa) || quantidadePessoa <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número inteiro e maior que zero!");
                    continue;
                }
                break;
            }
            for(int i = 0; i < quantidadePessoa; i++)
            {
                Console.Clear();
                Console.WriteLine($"\t  {i+1}ª Pessoa\n");
                while (true)
                {
                    Console.Write("Nome: ");
                    nome = Console.ReadLine().Trim();
                    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c=>char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite apenas um nome.\n");
                        continue;
                    }
                    break;
                }

                var opcoesSexosValidos = new string[] {"m","f"};

                while (true)
                {
                    Console.Write("Sexo: [m/f]");
                    sexo = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(sexo) || !opcoesSexosValidos.Contains(sexo))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite apenas: 'f' ou 'm'\n");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.Write("Idade: ");
                    string entradaIdade = Console.ReadLine().Trim().ToLower();
                    if (!int.TryParse(entradaIdade, out idade) || idade <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um número inteiro e maior que zero!");
                        continue;
                    }
                    break;
                }
                listaPessoas.Add(new Pessoa(nome,sexo,idade));
            }
            return listaPessoas;
        }

        private static int RetornarQuantidadePessoasMaioresDezoitoAnos(List<Pessoa> listaPessoas)
        {
            int quantidadePessoasMaioresDezoitoAnos = listaPessoas.Where(p=>p.Idade > 18).Count();
            return quantidadePessoasMaioresDezoitoAnos > 0 ? quantidadePessoasMaioresDezoitoAnos : 0;
        }

        private static int RetornarQuantidadeHomensCadastrados(List<Pessoa> listaPessoas)
        {
            int quantidadeHomensCadastrados = listaPessoas.Where(p=>p.Sexo == "m").Count();
            return quantidadeHomensCadastrados > 0 ? quantidadeHomensCadastrados : 0;
        }

        private static int RetornarQuantidadeMulheresMenoresVinteAnos(List<Pessoa> listaPessoas)
        {
            int quantidadeMulheresMenoresVinteAnos = listaPessoas.Where(p => p.Sexo == "f" && p.Idade < 20).Count();
            return quantidadeMulheresMenoresVinteAnos > 0 ? quantidadeMulheresMenoresVinteAnos : 0;
        }

        private static void ExibirDados()
        {
            var listaPessoas = RetornarListaPessoas();

            if (!listaPessoas.Any())
            {
                Console.WriteLine("Não há pessoas cadastradas!");
                return;
            }
            
            Console.Clear();
            int quantidadePessoasMaioresDezoitoAnos = RetornarQuantidadePessoasMaioresDezoitoAnos(listaPessoas);
            int quantidadeHomensCadastrados = RetornarQuantidadeHomensCadastrados(listaPessoas);
            int quantidadeMulheresMenoresVinteAnos = RetornarQuantidadeMulheresMenoresVinteAnos(listaPessoas);

            Console.WriteLine("Todas as pessoas cadastradas");
            foreach (var p in listaPessoas)
                Console.WriteLine(p.ToString());

            Console.WriteLine($"Quantidade de Pessoas Maiores de 18 Anos: {quantidadeHomensCadastrados}\nQuantidade de Homens Cadastrados: {quantidadeHomensCadastrados}\nQuantidade de Mulheres Menores de 20 Anos: {quantidadeMulheresMenoresVinteAnos}\n");
        }
    }
}
