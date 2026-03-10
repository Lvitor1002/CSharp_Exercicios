

/*
Crie uma matriz de paletes e, em seguida, classifique-as
string[] pallets = [ "B14", "A11", "B12", "A13" ];

                                    Ordenando pallets
                                    Inverter a ordem das paletes
*/
using System;
using System.Globalization;

namespace Fundamentos
{
    internal class Program
    {

        static void Main(string[] args)
            => ExibirPallets();

        private static void ExibirPallets()
        {
            /*
            Método 
            | --------------------- | ---------------------------- |
            | `Array.Reverse()`     | Inverte a ordem atual |
            | `pallets.Reverse()`   | Retorna sequência invertida  |
            | `OrderByDescending()` | Ordena do maior para o menor |*/


            string[] pallets = { "B14", "A11", "B12", "A13" };


            // Ordenando pallets 
            Console.WriteLine("Ordenando pallets");
            Array.Sort(pallets);
            foreach(var p in pallets) 
                Console.WriteLine(p);

            // Inverter a ordem das paletes
            Console.WriteLine("\nPallets invertidos");
            Array.Reverse(pallets);
            foreach (var p in pallets)
                Console.WriteLine(p);

            //limpar matriz(substitui por Null)
            Console.WriteLine("\nPallets limpos nas específicação fornecida ao método");
            Array.Clear(pallets, 0, 2);
            foreach (var p in pallets)
                Console.WriteLine(p);

            //Acessar o valor de um elemento limpo - Proposital
            //Console.WriteLine($"Retorna vazio: {pallets[0].ToLower()}");


            //Adicionar mais elementos à matriz 
            Array.Resize(ref pallets, 6);
            pallets[4] = "c01";
            pallets[5] = "c02";

            foreach (var p in pallets)
                Console.WriteLine(p);
        }
    }
}
