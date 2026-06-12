

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
using System.Collections.Generic;
using System.Linq;



namespace Fundamentos
{
    public static class Program
    {
        private static readonly string[] _arrayPrimeirosColocadosCampeonatoBR = {"PALMEIRAS", "ATLÉTICO MG", "BOTAFOGO", "FLAMENGO", "GRÊMIO",
                                                                        "RED BULL", "FLUMINENSE", "ATHLETICO PR", "SÃO PAULO", "INTERNACIONAL",
                                                                        "CHAPECOENSE", "FORTALEZA", "CUIABÁ", "CORINTHIANS", "CRUZEIRO",
                                                                        "SANTOS", "VASCO", "BAHIA", "GOIÁS", "CURITIBA", "AMÉRICA MG"};

        private static void Main(string[] args)
            => ExibirDados();


        

        //Usando IEnumerable<string> pois não é preciso definir o tipo da coleção que está sendo retornada, a mesma pode ser lista, array, etc.. e quem chama o método não precisa saber se os dados vêm de um array, lista ou outra coleção.
        private static IEnumerable<string> RetornarCincoPrimeirosTimes()
            => _arrayPrimeirosColocadosCampeonatoBR.Take(5);

        private static IEnumerable<string> RetornarQuatroUltimosColocados()
            => _arrayPrimeirosColocadosCampeonatoBR.Skip(_arrayPrimeirosColocadosCampeonatoBR.Length - 4);

        private static IEnumerable<string> RetornarTimesOrdemAlfabetica()
            => _arrayPrimeirosColocadosCampeonatoBR.OrderBy(t=>t);

        private static int RetornarPosicaoTimeChapecoense()
            => Array.IndexOf(_arrayPrimeirosColocadosCampeonatoBR, "CHAPECOENSE") + 1;

     
        private static int RetornarPosicaoTimeEscolhido()
        {
            while (true)
            {
                Console.WriteLine("Digite o nome de um time para saber a posição: ");
                string timeEscolhido = Console.ReadLine().ToUpper();
                if(string.IsNullOrEmpty(timeEscolhido) || !timeEscolhido.All(c=>char.IsLetter(c) || c == ' '))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Por favor, digite um nome de time válido.");
                    continue;
                }

                if (_arrayPrimeirosColocadosCampeonatoBR.FirstOrDefault(t => t.Equals(timeEscolhido, StringComparison.OrdinalIgnoreCase)) == null) //Ignora diferença entre maiúsculas e minúsculas.
                {
                    Console.Clear();
                    Console.WriteLine($"O time {timeEscolhido} não está na lista dos 21 primeiros colocados. Por favor, tente novamente.");
                    continue;
                };

                return Array.IndexOf(_arrayPrimeirosColocadosCampeonatoBR, timeEscolhido) + 1;
            }
        }

        private static void ExibirMenu() 
        {
            AQUI
        }
        private static void ExibirDados()
        {
            //Console.WriteLine($"{string.Join(", ", RetornarTimesOrdemAlfabetica())}.");
                    //Console.WriteLine($"O time {timeEscolhido} está na {Array.IndexOf(_arrayPrimeirosColocadosCampeonatoBR, timeEscolhido) + 1}ª posição.\n");
        } 
    }
}
