
/*
Crie uma matriz de paletes e, em seguida, classifique-as
string[] pallets = [ "B14", "A11", "B12", "A13" ];

                                    Ordenando pallets
                                    Inverter a ordem das paletes
*/



using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentos
{
    public static class Program
    {
        private static string[] pallets = new string[] { "B14", "A11", "B12", "A13" };

        private static void Main(string[] args)
            => ExibirDados();

        private static IEnumerable<string> RetornarPalletsOrdenados()
            => pallets.OrderBy(p => p);

        private static IEnumerable<string> RetornarPalletsDecrescente()
            => pallets.OrderByDescending(p => p);

        private static void ExibirDados()
        {
            Console.WriteLine($"Pallets Ordenados: {string.Join(", ", RetornarPalletsOrdenados())}.");
            Console.WriteLine($"Pallets em Ordem Decrescente: {string.Join(", ", RetornarPalletsDecrescente())}.");


            /*
            Método 
            | --------------------- | ---------------------------- |
            | `Array.Reverse()`     | Inverte a ordem atual |
            | `pallets.Reverse()`   | Retorna sequência invertida  |
            | `OrderByDescending()` | Ordena do maior para o menor |*/

            // Ordenando pallets 
            //Console.WriteLine("Ordenando pallets");
            //Array.Sort(pallets);
            //foreach (var p in pallets)
            //    Console.WriteLine(p);

            // Inverter a ordem das paletes
            //Console.WriteLine("\nPallets invertidos");
            //Array.Reverse(pallets);
            //foreach (var p in pallets)
            //    Console.WriteLine(p);

            //limpar matriz(substitui por Null)
            //Console.WriteLine("\nPallets limpos nas específicação fornecida ao método");
            //Array.Clear(pallets, 0, 2);
            //foreach (var p in pallets)
            //    Console.WriteLine(p);

            //Acessar o valor de um elemento limpo - Proposital
            //Console.WriteLine($"Retorna vazio: {pallets[0].ToLower()}");


            //Adicionar mais elementos à matriz 
            //Array.Resize(ref pallets, 6);
            //pallets[4] = "c01";
            //pallets[5] = "c02";

            //foreach (var p in pallets)
            //    Console.WriteLine(p);
        }
    }
}
