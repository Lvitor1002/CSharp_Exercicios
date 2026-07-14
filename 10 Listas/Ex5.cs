



/*
    Faça um programa que leia nome e peso de várias pessoas, guardando tudo em uma lista. 
    No final, mostre:
                    A) Quantas pessoas foram cadastradas.
                    B) Pessoa mais pesada.
                    C) Pessoa mais leve.
*/


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Fundamentos
{
    public static class Program
    {

        private static void Main(string[] args)
            => ExibirDados();


        private static List<Pessoa> RetornarListaPessoas()
        {
            var listaPessoas = new List<Pessoa>();
            int qtdPessoas;
            string nome;
            float peso = 0;

            while (true)
            {
                Console.Write("Digite a quantidade de pessoas a serem cadastradas: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out qtdPessoas) || qtdPessoas <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número inteiro e maior que zero.");
                    continue;
                }
                break;
            }

            for(int i = 0; i < qtdPessoas; i++)
            {
                Console.Clear();
                Console.WriteLine($"Pessoa {i + 1}:");
                while (true)
                {
                    Console.Write("Digite o nome da pessoa: ");
                    nome = Console.ReadLine().Trim();
                    if(string.IsNullOrWhiteSpace(nome) || !nome.All(c=>char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Nome inválido. Digite apenas letras e espaços.");
                        continue;
                    }
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }
                while (true)
                {
                    Console.Write("Digite o peso da pessoa: ");
                    string entrada = Console.ReadLine().Trim().Replace(".",",");
                    if (!float.TryParse(entrada, NumberStyles.Float, CultureInfo.CurrentCulture,out peso) || peso <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um número inteiro ou real maior que zero.");
                        continue;
                    }
                    break;
                }
                listaPessoas.Add(new Pessoa(nome, peso));
            }
            return listaPessoas;
        }
      
        private static int RetornarQuantidadePessoas(List<Pessoa> listaPessoas)
            => listaPessoas.Count;

        private static Pessoa RetornarPessoaMaisPesada(List<Pessoa> listaPessoas)
            => listaPessoas.Count > 0 ? listaPessoas.OrderByDescending(p => p.Peso).First() : null;

        private static Pessoa RetornarPessoaMaisLeve(List<Pessoa> listaPessoas)
            => listaPessoas.Count > 0 ? listaPessoas.OrderBy(p => p.Peso).First() : null;


        private static void ExibirDados()
        {
            var listaPessoas = RetornarListaPessoas();
            var pessoaMaisPesada = RetornarPessoaMaisPesada(listaPessoas);
            var pessoaMaisLeve = RetornarPessoaMaisLeve(listaPessoas);

            Console.Clear();

            if(listaPessoas.Count == 0)
            {
                Console.WriteLine("Nenhuma pessoa cadastrada.");
                return;
            }

            Console.WriteLine($"\n--------------------------------------------------");
            Console.WriteLine("Todas as pessoas cadastradas:\n");
            foreach(var pessoa in listaPessoas)
                Console.WriteLine(pessoa);
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine($"{RetornarQuantidadePessoas(listaPessoas)} pessoas foram cadastradas.\n");
            Console.WriteLine(pessoaMaisPesada != null ? $"{pessoaMaisPesada.Nome} é a pessoa mais pesada cadastrada, pesando {pessoaMaisPesada.Peso}Kg.\n" : "\n");
            Console.WriteLine(pessoaMaisLeve != null ? $"{pessoaMaisLeve.Nome} é a pessoa mais leve cadastrada, pesando {pessoaMaisLeve.Peso}Kg.\n" : "\n");
        }


        private class Pessoa
        {
            public string Nome { get; set; }
            public float Peso{ get; set; }

            public Pessoa(string nome, float peso)
            {
                Nome = nome;
                Peso = peso;
            }

            public override string ToString()
                =>$"Nome: {Nome}\nPeso: {Peso:F2} kg\n";
            
        }
    }
}
