
/*
exer_expressoes

                    //Produtos de categoria [simples] com preço menor que R$900
                    //Nome dos produtos da categoria Escolar 
                    //Produtos de Categoria 2 ordenados por preço 
                    //Maior preço da lista
                    //Soma dos produtos de id 1
*/

using System;
using System.Linq;
using System.Collections.Generic;
using TREINO.Entities;
using TREINO.Entities.Enums;


namespace TREINO
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        static List<Produto> Leitura()
        {
            Categoria c1 = new Categoria() { Id = 1, Nome = "Escolar", Nivel = Nivel.Simples};
            Categoria c2 = new Categoria() { Id = 2, Nome = "Computadores", Nivel = Nivel.Medio};
            Categoria c3 = new Categoria() { Id = 3, Nome = "Eletrônicos", Nivel = Nivel.Robusto };

            var listaProdutos = new List<Produto>() {new Produto() { Id = 1, Nome = "Computador", Preco = 4500.00, Categoria = c2 },
                                                    new Produto() { Id = 2, Nome = "Mouse", Preco = 50.00, Categoria = c3 },
                                                    new Produto() { Id = 3, Nome = "Teclado", Preco = 120.00, Categoria = c3 },
                                                    new Produto() { Id = 4, Nome = "Caderno Espiral", Preco = 15.00, Categoria = c1 },
                                                    new Produto() { Id = 5, Nome = "Notebook", Preco = 3800.00, Categoria = c2 },
                                                    new Produto() { Id = 6, Nome = "Impressora", Preco = 750.00, Categoria = c2 },
                                                    new Produto() { Id = 7, Nome = "Fone de Ouvido", Preco = 200.00, Categoria = c3 },
                                                    new Produto() { Id = 8, Nome = "Lápis", Preco = 2.50, Categoria = c1 },
                                                    new Produto() { Id = 9, Nome = "Tablet", Preco = 2500.00, Categoria = c2 },
                                                    new Produto() { Id = 10, Nome = "Smartphone", Preco = 3000.00, Categoria = c3 },
                                                    new Produto() { Id = 11, Nome = "Agenda", Preco = 25.00, Categoria = c1 },
                                                    new Produto() { Id = 12, Nome = "Câmera Digital", Preco = 1200.00, Categoria = c3 },
                                                    new Produto() { Id = 13, Nome = "Monitor", Preco = 950.00, Categoria = c2 },
                                                    new Produto() { Id = 14, Nome = "Pen Drive", Preco = 40.00, Categoria = c3 },
                                                    new Produto() { Id = 15, Nome = "Borracha", Preco = 1.50, Categoria = c1 }
            };
            return listaProdutos;
        }
        static void Exibir()
        {
            var listaProdutos = Leitura();

            Console.Clear();


            //Produtos de categoria [simples] com preço menor que R$900
            var p1 = listaProdutos.Where(x => x.Categoria.Nivel == Nivel.Simples && x.Preco < 900).OrderBy(x =>x.Preco).Select(x => new { x.Categoria.Nivel, x.Preco}).ToList();
            var p1Formatado = string.Join(" ",p1.Select(x => $"\nNivel: {x.Nivel}\nPreço: R${x.Preco:F2}\n"));

            Console.WriteLine($"Produtos de categoria [simples] com preço menor que R$900:\n{p1Formatado} \n-----------------------------------------\n");


            //Nome dos produtos da categoria Escolar 
            var p2 = listaProdutos.Where(x=>x.Categoria.Nome == "Escolar").Select(x => new { x.Nome }).ToList();
            var p2Formatado = string.Join(" ", p2.Select(x => $"\n{x.Nome}\n"));
            Console.WriteLine($"Nome dos produtos da categoria Escolar:\n{p2Formatado} \n-----------------------------------------\n");

            //Produtos de Categoria 2 ordenados por preço 
            var p3 = listaProdutos.Where(x=>x.Categoria.Nivel == Nivel.Medio).OrderBy(x=>x.Preco).Select(x=> new {x.Categoria.Nivel, x.Preco}).ToList();
            var p3Formatado = string.Join(" ", p3.Select(x => $"\nCategoria 2 - {x.Nivel}\nPreço: R${x.Preco:F2}\n"));
            Console.WriteLine($"Produtos de Categoria 2 ordenados por preço:\n{p3Formatado} \n-----------------------------------------\n");


            //Maior preço da lista
            double p4 = listaProdutos.Max(x => x.Preco);
            Console.WriteLine($"Maior preço da lista: R${p4:F2} \n-----------------------------------------\n");

            //Soma dos produtos de id 1
            double p5 = listaProdutos.Where(x => x.Id == 1).Sum(x=>x.Preco);
            Console.WriteLine($"Soma dos produtos de id 1: R${p5:F2} \n-----------------------------------------\n");
        }
    }
}
