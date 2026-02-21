
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

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();


        private static List<Pessoa> Leitura()
        {
            var listaPessoas = new List<Pessoa>();
            string nome;
            int idade, quantidadePessoas = 0;
            char sexo;
            while (true)
            {
                Console.Write("Entre com a quantidade de pessoas cadastradas: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out quantidadePessoas) || quantidadePessoas <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro positivo.");
                    continue;
                }
                break;
            }
            for(int i =0; i<quantidadePessoas; i++)
            {
                Console.Clear();
                Console.WriteLine($"Cadastro da {i + 1}ª pessoa:");
                while (true)
                {
                    Console.Write("Entre com o nome do usuário: ");
                    nome = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c=>char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um nome válido.");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write("Entre com o sexo [m/f]: ");
                    string entrada = Console.ReadLine().Trim().ToLower();
                    if (!char.TryParse(entrada, out sexo) || (sexo != 'm' && sexo != 'f'))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um sexo válido[m/f].");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write("Entre com a idade: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out idade) || idade <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Por favor, insira uma idade positivo.");
                        continue;
                    }
                    break;
                }
                listaPessoas.Add(new Pessoa(nome, idade, sexo));
            }
            return listaPessoas;
        }
        private static void Exibir()
        {
            var listaPessoas = Leitura();
            Console.Clear();
            Console.WriteLine(string.Join("\n", listaPessoas));
            Console.WriteLine($"\nQuantidade de pessoas com mais de 18 anos: {listaPessoas.Count(p => p.Idade > 18)} Pessoas");
            Console.WriteLine($"Quantidade de homens cadastrados: {listaPessoas.Count(p => p.Sexo == 'm')} Homens");
            Console.WriteLine($"Quantidade de mulheres com menos de 20 anos: {listaPessoas.Count(p => p.Sexo == 'f' && p.Idade < 20)} Mulheres");
        }

        private class Pessoa
        {
            public string Nome{ get; set; }
            public int Idade{ get; set; }
            public char Sexo{ get; set; }

            public Pessoa(string nome, int idade, char sexo)
            {
                Nome = nome;
                Idade = idade;
                Sexo = sexo;
            }

            public override string ToString()
            {
                return $"Nome: {Nome}\n" +
                    $"Idade: {Idade}\n" +
                    $"Sexo: {Sexo}\n" +
                    $"-=-=-=-=-=-=-=-=-=";
            }
        }
    }
}

