


/* 
Crie um programa que tenha uma tupla única com nomes de produtos e seus respectivos preços, na sequência. 
No final, mostre uma listagem de preços, organizando os dados em forma tabular.
*/

using System;
using System.Linq;

namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();
        private static (string, decimal)[] RetornaProdutos()
        {
            return new (string Nome, decimal Preco)[]
                {("Caderino", 10.49m),
                ("Panela", 80.99m),
                ("Chaleira", 10.99m),
                ("Maquina", 70.99m),
                ("Caderno", 90.99m),
                ("Lustre", 60.99m),
                ("Arroz", 20.99m),
                ("Luva", 70.99m),
                ("Mesa", 550.99m),
                ("Pia", 870.99m),
                ("Colchão", 100.99m),
                ("Seda", 887.99m),
                ("Panela", 81.99m)};
        }
        private static void Exibir()
        {
            var produtos = RetornaProdutos();
            var produtosFormatados = produtos.Select(p => $"{p.Item1,-10} - \t{p.Item2,6:C}").ToArray();
            Console.WriteLine(">Produtos:\n-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            Console.WriteLine($"{string.Join("\n", produtosFormatados)}");
            Console.WriteLine("\n-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
        }
    }
}

