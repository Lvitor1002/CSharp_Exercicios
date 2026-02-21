
/*
Crie um programa que leia o nome e o preço de vários produtos. 
O programa deverá perguntar se o usuário vai continuar ou não. No final, mostre:
A) qual é o total gasto na compra.
B) quantos produtos custam mais de R$1000.
C) qual é o nome do produto mais barato.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();

        private static List<Produto> RetornaTodosProdutos()
        {
            var listaProdutos = new List<Produto>();
            string nome;
            decimal preco;
            int i = 0;
            while (true)
            {
                Console.Clear();
                i++;    
                Console.WriteLine($"{i}ª Produto");
                while (true)
                {
                    Console.Write("Entre com o nome do produto: ");
                    nome = Console.ReadLine().Trim().ToLower();
                    if(string.IsNullOrWhiteSpace(nome) || ! nome.All(c=> char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Nome inválido. Tente novamente.");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write("Entre com o preço do produto: R$");
                    string entrada = Console.ReadLine().Trim();
                    if (!decimal.TryParse(entrada, out preco) || preco <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' ou 'real' positivo.");
                        continue;
                    }
                    break;
                }
                listaProdutos.Add(new Produto(nome, preco));
                while (true)
                {
                    Console.Write("Deseja continuar? [s/n]: ");
                    string entrada = Console.ReadLine().Trim().ToLower();
                    if (entrada == "n")
                        return listaProdutos;
                    break;
                }
            }
        }
        private static void Exibir()
        {
            var listaProdutos = RetornaTodosProdutos();

            Console.Clear();
            Console.WriteLine($"A) Total gasto na compra: R${listaProdutos.Sum(x=>x.Preco).ToString("C", new CultureInfo("pt-BR"))}");
            Console.WriteLine($"B) Quantidade de produtos com preço maior de R$1000: {listaProdutos.Count(x=>x.Preco > 1000)} produto(s)");
            var produtoMaisBarato = listaProdutos.OrderBy(x => x.Preco).First(); // Obtém o produto mais barato
            Console.WriteLine($"C) Nome do produto mais barato: {produtoMaisBarato.Nome} - Preço: {produtoMaisBarato.Preco}\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine($"Todos os produtos: {string.Join("\n",listaProdutos)}\n");
        }
    }
    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public override string ToString()
            => $"Nome: {Nome}\nPreço: {Preco.ToString("C", new CultureInfo("pt-BR"))}\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=";
    }
}

