

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


namespace Fundamentos
{
    public class Produto
    {
        public string Nome{ get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public override string ToString()
            => $@"
Nome: {Nome}
Preço: {Preco:F2}
";
    }

    public static class Program
    {
        private static void Main(string[] args)
            => ExibirDados();

        private static List<Produto> RetornarListaProdutos()
        {
            var listaProdutos = new List<Produto>();
            string nome;
            decimal preco;
            int contador = 0;

            while (true)
            {
                Console.Clear();
                contador++;
                while (true)
                {
                    Console.Write($"Nome do {contador}ª produto: ");
                    nome = Console.ReadLine().Trim();
                    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c => char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite apenas um nome.\n");
                        continue;
                    }
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }

                while (true)
                {
                    Console.Write($"Preço do {nome}: ");
                    string entradaPreco = Console.ReadLine().Trim().ToLower();
                    if (!decimal.TryParse(entradaPreco, out preco) || preco <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um número inteiro ou real, maior que zero!");
                        continue;
                    }
                    break;
                }

                var opcoesValidas = new string[] { "s", "n" };

                while (true)
                {
                    Console.Write("Deseja continuar: [s/n]");
                    string entrada = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(entrada) || !opcoesValidas.Contains(entrada))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite apenas: 's' ou 'n'\n");
                        continue;
                    }
                    listaProdutos.Add(new Produto(nome,preco));

                    if(entrada == "n")
                        return listaProdutos;
                    else
                        break;
                }
            }
        }
        
        private static decimal RetornarTotalCompra(List<Produto> listaProdutos)
            => listaProdutos.Sum(p=>p.Preco);

        private static int RetornarQuantidadeProdutosPrecoMaiorMil(List<Produto> listaProdutos)
        {
            int quantidade = listaProdutos.Where(p => p.Preco > 1000).Count();
            return quantidade > 0 ? quantidade : 0;
        }

        private static (string, decimal) RetornarDadosProdutoMaisBarato(List<Produto> listaPessoas)
        {
            var dados = listaPessoas.OrderBy(p => p.Preco).Select(p => new {p.Nome,p.Preco}).First();
            return (dados.Nome, dados.Preco);
        }


        private static void ExibirDados()
        {
            var listaProdutos = RetornarListaProdutos();

            if (!listaProdutos.Any())
            {
                Console.WriteLine("Não há produtos cadastradas!");
                return;
            }
            
            Console.Clear();
            int quantidadeProdutosPrecoMaiorMil = RetornarQuantidadeProdutosPrecoMaiorMil(listaProdutos);
            var (nomeProdutoMaisBarato, precoProdutoMaisBarato) = RetornarDadosProdutoMaisBarato(listaProdutos);

            Console.WriteLine("Todas os produtos cadastradas");
            foreach (var p in listaProdutos)
                Console.WriteLine(p.ToString());

            Console.WriteLine($"\nTotal gasto na compra: R${RetornarTotalCompra(listaProdutos):F2}");
            Console.WriteLine(quantidadeProdutosPrecoMaiorMil > 0 ? $"Quantidade de produtos que custam mais de R$1000: {quantidadeProdutosPrecoMaiorMil}" : "Não há produtos com preço maior do que R$1000.");
            Console.WriteLine($"Produto mais barato: {nomeProdutoMaisBarato} - R${precoProdutoMaisBarato:F2}\n");
        }
    }
}
