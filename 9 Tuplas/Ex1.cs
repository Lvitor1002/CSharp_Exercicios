/* 
Crie uma tupla preenchida com os 21 primeiros colocados da Tabela do Campeonato Brasileiro de Futebol, 
na ordem de colocação. Depois mostre:
a) Os 5 primeiros times.
b) Os últimos 4 colocados.
c) Times em ordem alfabética. 
d) Em que posição está o time da Chapecoense.
e) Escolha um time para saber a posição
*/

using System;
using System.Linq;

namespace TREINO
{
    class Program
    {
        static void Main() => EscolhaMenu();

        static readonly string[] times = {
            "PALMEIRAS", "ATLÉTICO MG", "BOTAFOGO", "FLAMENGO", "GRÊMIO",
            "RED BULL", "FLUMINENSE", "ATHLETICO PR", "SÃO PAULO", "INTERNACIONAL",
            "CHAPECOENSE", "FORTALEZA", "CUIABÁ", "CORINTHIANS", "CRUZEIRO",
            "SANTOS", "VASCO", "BAHIA", "GOIÁS", "CURITIBA", "AMÉRICA MG"
        };
        private static void Menu()
            =>Console.WriteLine("a) Os 5 primeiros times.\r\nb) Os últimos 4 colocados.\r\nc) Times em ordem alfabética. \r\nd) Em que posição está o time da Chapecoense.\r\ne) Escolha um time para saber a posição");
        private static void EscolhaMenu()
        {
            var validas = new[] { 'a', 'b', 'c', 'd', 'e' };
            Menu();
            while (true)
            {
                string entrada = Console.ReadLine().Trim().ToLower();
                if (!char.TryParse(entrada, out char escolha) || !validas.Contains(escolha))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com uma das opções válidas.");
                    Menu(); 
                    continue;
                }
                switch (escolha)
                {
                    case 'a':
                        Console.Clear();
                        CincoPrimeirosTimes();
                        break;

                    case 'b':
                        Console.Clear();
                        UltimosQuatroTimes();
                        break;

                    case 'c':
                        Console.Clear();
                        TimesOrdemAlfabetica();
                        break;

                    case 'd':
                        Console.Clear();
                        PosicaoChapecoense();
                        break;

                    case 'e':
                        Console.Clear();
                        PosicaoTimeEscolhido();
                        break;
                }
                break;
            }   
        }

        private static void PosicaoTimeEscolhido()
        {
            string entrada;
            while (true)
            {
                Console.Write("e) Escolha um time para saber a posição: ");
                entrada = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um time válido.");
                    Menu();
                    continue;
                }
                break;
            }
            //A comparação é feita pelo valor exato do caractere na tabela Unicode.
            //Ignora diferença entre maiúsculas e minúsculas.
            var timeEscolhido = times.FirstOrDefault(x => x.Equals(entrada, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(timeEscolhido != null                 
                ? $"O time {timeEscolhido} está na {Array.IndexOf(times, timeEscolhido) + 1}ª posição.\n"
                : $"O time {entrada} não está na lista dos 21 primeiros colocados.\n");
        }


        private static void PosicaoChapecoense()
        {
            var posicaoChapecoense = Array.IndexOf(times, "CHAPECOENSE") + 1;
            Console.WriteLine($"A Chapecoense está na {posicaoChapecoense}ª posição.\n");
        }

        private static void TimesOrdemAlfabetica()
        {
            var timesOrdemAlfabetica = times.OrderBy(x=>x);
            Console.WriteLine($"Times em ordem alfabética:\n{string.Join("\n", timesOrdemAlfabetica)}\n");
        }

        private static void UltimosQuatroTimes()
        {
            var ultimosQuatroTimes = times.Skip(times.Length - 4);
            Console.WriteLine($"Os 4 últimos times: {string.Join(", ", ultimosQuatroTimes)}\n");
        }

        private static void CincoPrimeirosTimes()
        {
            var cincoPrimeiros = times.Take(5);
            Console.WriteLine($"Os 5 primeiros times: {string.Join(", ", cincoPrimeiros)}\n");
        }
    }
}

