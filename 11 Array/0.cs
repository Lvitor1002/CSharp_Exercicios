
/*
Desafio de código - Relatar os IDs de pedido que precisam de investigação adicional

Sua equipe encontrou um padrão. 
As encomendas que começam com a letra "B" encontram fraudes a uma taxa 25 vezes superior à taxa normal. 
Você escreve um novo código que gera o ID do pedido de novos pedidos, onde o ID do pedido começa com a letra "B". 
Isso será usado pela equipe de fraude para investigar mais. 

Declare uma matriz e inicialize-a para conter os seguintes elementos:
                                                                    B123
                                                                    C234
                                                                    A345
                                                                    C15
                                                                    B177
                                                                    G3003
                                                                    C235
                                                                    B179
Esses valores representam os dados fraudulentos de ID do pedido que seu aplicativo usa.

Informe os IDs de pedido que começam com a letra "B".

Você precisa avaliar cada elemento da matriz. 
Denuncie os IDs de pedidos potencialmente fraudulentos detetando os pedidos que começam com a letra "B".
*/
using System;
using System.Linq;


namespace Etapa1
{
    public class Program
    {
        public static void Main(string[] args)
            => ExibirMensagemIdsFraude();

        private static void ExibirMensagemIdsFraude()
        {
            string[] fraudulentOrderIDs = { "B123","C234","A345","C15","B177","G3003","C235","B179"};

            //Forma tradicional de fazer usando um loop
            Console.WriteLine("IDs de pedidos que precisam de investigação adicional: ");
            foreach (var id in fraudulentOrderIDs)
                if(id.StartsWith("B"))
                    Console.WriteLine(id);


            //Outra forma de fazer usando LINQ
            var idsFraude = string.Join(",", fraudulentOrderIDs.Where(id => id.StartsWith("B")));
            Console.WriteLine($"\nIDs de pedidos que precisam de investigação adicional usando LINQ: {idsFraude}");
        }
    }
}
