

/*
Combine valores de um array de strings como strings e como inteiros

É necessário implementar as seguintes regras de negócios em sua lógica de código:

                    Regra 1: Se o valor for alfabético, concatene-o para formar uma mensagem.

                    Regra 2: Se o valor for numérico, adicione-o ao total.

                    Regra 3: O resultado deve corresponder à seguinte saída:

Output esperado:
                Message: ABCDEF
                Total: 68.3
*/
using System;
using System.Globalization;

namespace Fundamentos
{
    internal class Program
    {

        static void Main(string[] args)
            => ConverterValores();

        private static void ConverterValores()
        {
            string[] values = { "12.3", "45", "ABC", "11", "DEF" };

            string mensagem = "";
            decimal total = 0m;

            foreach (var valor in values)
            {
                if (decimal.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valorConvetidoEmDecimal))
                    total += valorConvetidoEmDecimal;
                else
                    mensagem += valor;
            }
            Console.WriteLine($"Mensagem: {mensagem}\nTotal: {total}");
        }
    }
}
