
/*
Combine valores de um array de strings como strings e como inteiros

string[] values = { "12.3", "45", "ABC", "11", "DEF" };


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
using System.Linq;

namespace Fundamentos
{
    public class Program
    {

        private static void Main(string[] args)
            => ExibirDados();


        private static (string, decimal[]) RetornarArrays()
        {
            string[] values = { "12.3", "45", "ABC", "11", "DEF" };
            string conjuntoLetras = "";
            var conjuntoNumeros = new decimal[values.Length];

            for(int i = 0; i < values.Length; i++)
                if(decimal.TryParse(values[i], NumberStyles.Any,CultureInfo.InvariantCulture, out decimal numero))
                    conjuntoNumeros[i] += numero;
                else
                    conjuntoLetras += values[i];

            return (conjuntoLetras, conjuntoNumeros);
        }
        private static void ExibirDados()
        {
            var (conjuntoLetras, conjuntoNumeros) = RetornarArrays();
            Console.Clear();

            Console.WriteLine($@"
Mensagem: {string.Join("",conjuntoLetras)}
Total: {conjuntoNumeros.Sum(x=>x).ToString().Replace(",","."):F1}              
");

        }

    }
}
