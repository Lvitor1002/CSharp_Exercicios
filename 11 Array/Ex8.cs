

/*
Split() e Join()
*/
using System;
using System.Globalization;

namespace Fundamentos
{
    internal class Program
    {

        static void Main(string[] args)
            => Processos();

        private static void Processos()
        {

            //Convertendo string em um array de char
            string valor = "abc123";
            char[] arrayDeChar = valor.ToCharArray();

            
            
            // Inverter a ordem do arrayDeChar, em seguida, combinar a matriz char em uma nova cadeia de caracteres
            Array.Reverse(arrayDeChar);
            var novaCadeiaCaractes = new string(arrayDeChar);



            //Percorrendo um array separando os elementos por vírgula
            var arrayCharSeparadoPorVirgula = string.Join(",", arrayDeChar);



            /*
                Split:
                    A vírgula é fornecida como .Split() sendo o (delimitador) para dividir uma cadeia longa de caracteres em um cadeia menor. 
            */
            string[] items = arrayCharSeparadoPorVirgula.Split(','); //Onde tem virgula, quebra, para uma nova cadeia
            Console.WriteLine("\nSplit");
            foreach(var i in items)
                Console.WriteLine(i);

        }
    }
}
