

/*
Uma locadora brasileira de carros cobra um valor por hora para locações de até 12 horas. 
Porém, se a duração da locação ultrapassar 12 horas, a locação será cobrada com base em um valor diário. 

Além do valor da locação, é acrescido no preço o valor do imposto conforme regras do país que, 
no caso do Brasil, é; 
                     20% para valores até 100.00, 
                                    ou
                     15% para valores acima de 100.00. 

Fazer um programa que lê os dados da locação;
                                             modelo do carro, 
                                             instante inicial da locação,
                                             instante final da locação, 
                                             valor por hora,
                                             valor diário de locação. 

O programa deve então informar os dados da nota de pagamento na tela, contendo; 
                                                                               valor da locação, 
                                                                               valor do imposto,
                                                                               valor total do pagamento.
 */



using System;
using System.Globalization;
using treino.Entities;
using treino.Entities.Enums;



namespace TREINO
{
    class Program
    {
        static void Main(string[] args)
        {
            ExibirDados();
        }
        public static Locacao LeituraDados()
        {
            Modelo modelo;
            DateTime instanteFinal; 
            decimal valorPorHora, valorDiario;

            while (true)
            {

                Console.Write("Entre com o modelo do carro: Hatch | Sedã | SUV | Picape - ");
                string modeloC = Console.ReadLine().Trim();
                if(!Enum.TryParse<Modelo>(modeloC, true, out modelo))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com uma das opções a seguir: Hatch | Sedã | SUV | Picape");
                    continue;
                }
                break;
            }
            while (true)
            {

                Console.Write("Entre com a data final da locação do carro, ex: dd/mm/yyyy - ");
                string dataF = Console.ReadLine().Trim();
                if (!DateTime.TryParseExact(
                    dataF, 
                    "dd/MM/yyyy", 
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out instanteFinal) || instanteFinal <= DateTime.Now)
                {
                    Console.Clear();
                    Console.WriteLine($"Entrada inválida. Digite uma data maior que {DateTime.Now}");
                    continue;
                }
                break;
            }
            while (true)
            {

                Console.Write("Entre com o valor cobrado por hora da locação do carro: R$");
                string valorPH = Console.ReadLine().Trim();
                if (!decimal.TryParse(valorPH, out valorPorHora) || valorPorHora <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um valor válido 'inteiro' ou 'real' maior que zero!");
                    continue;
                }
                break;
            }
            while (true)
            {

                Console.Write("Entre com o valor cobrado por dia da locação do carro: R$");
                string valorPD = Console.ReadLine().Trim();
                if (!decimal.TryParse(valorPD, out valorDiario) || valorDiario <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um valor válido 'inteiro' ou 'real' maior que zero!");
                    continue;
                }
                break;
            }

            Locacao locacao = new Locacao(modelo,instanteFinal,valorPorHora,valorDiario);
            return locacao;
        }

        public static void ExibirDados()
        {
            var locacao = LeituraDados();

            Console.Clear();
            Console.WriteLine(locacao);
        }
    }
}

