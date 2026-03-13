

/*
Usar métodos para calcular o preço total de compra
O Shopping Center Contoso está tendo uma super venda! Muitos itens têm preço com desconto. 

Você recebe uma lista de preços de itens e uma lista de descontos correspondentes. 
Os descontos são representados por percentagens, por exemplo 50% = 0,5. 
Se um cliente gastar mais de 30,00 recebe 5,00 de desconto do total da compra. 

Nesta tarefa, você escreverá código para calcular o total do cliente

*/

using System;

namespace Fundamentos
{
    internal class Program
    {
        private static double _total = 0;
        private static double _gastoMinimo = 30.00;

        private static double[] _items = { 15.97, 3.50, 12.25, 22.99, 10.98 };
        private static double[] _desconto = { 0.30, 0.00, 0.10, 0.20, 0.50 };


        private static void Main(string[] args)
            => ProcessarMetodos();
        
        private static double GetDiscountedPrice(int itemIndex) //Assinatura do método é o seu tipo definido para retorno(double).
            => _items[itemIndex] * (1 - _desconto[itemIndex]);

        private static bool TotalMeetsMinimum()
            => _total >= _gastoMinimo;

        private static string FormatDecimal(double input)
            => input.ToString().Substring(0, 5).Replace(",",".");


        private static void ProcessarMetodos()
        {
            for (int i = 0; i < _items.Length; i++)
                _total += GetDiscountedPrice(i); // O total será a soma de cada valor de um item, já com desconto aplicado 
            
            _total -= TotalMeetsMinimum() ? 5.00 : 0.00;
            
            Console.WriteLine($"Total dos itens: R${FormatDecimal(_total)}");
        }
    }
}
