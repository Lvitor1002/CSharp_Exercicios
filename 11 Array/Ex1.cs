

/*
Os dados vêm em muitos formatos. 
Neste desafio, você tem que analisar os "IDs de pedido" individuais e produzir os "OrderIDs" 
classificando-os como "Erro" se eles não tiverem exatamente quatro caracteres de comprimento.

string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";


Seu código deve produzir a seguinte saída:
                                            A345
                                            B123
                                            B177
                                            B179
                                            C15     - Error
                                            C234
                                            C235
                                            G3003   - Error
*/

using System;

namespace Fundamentos
{
    internal class Program
    {

        static void Main(string[] args)
            => ManipulandoIDsPedido();

        private static void ManipulandoIDsPedido()
        {
            string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";

            string[] ids = orderStream.Split(',');
            Array.Sort(ids);

            foreach (var id in ids) 
            { 
                if(id.Length == 4)
                    Console.WriteLine(id);
                else
                    Console.WriteLine($"{id}\t- Erro");
            }
        }
    }
}
