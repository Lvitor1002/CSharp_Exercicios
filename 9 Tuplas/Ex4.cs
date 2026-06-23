

/* 
Crie um programa que tenha uma tupla única com nomes de produtos e seus respectivos preços, na sequência. 
No final, mostre uma listagem de preços, organizando os dados em forma tabular.
*/


using System;



namespace Fundamentos
{
    public static class Program
    {

        private static void Main(string[] args)
            => ExibirDados();

        private static (string, decimal)[] RetornarArrayProdutos()
            => new (string, decimal)[]
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



        private static void ExibirDados()
        {
            Console.WriteLine("Produto      -      Preço\n");
            foreach (var produto in RetornarArrayProdutos())
                Console.WriteLine($"{produto.Item1.PadRight(20)}{produto.Item2:C2}");
        }
    }
}
