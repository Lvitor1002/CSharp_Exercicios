

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


        //Dica: IEnumerable<string> pois não é preciso definir o tipo da coleção que está sendo retornada, a mesma pode ser lista, array, etc.. e quem chama o método não precisa saber se os dados vêm de um array, lista ou outra coleção.
        

        private static void ExibirCincoPrimeirosTimes()
            => Console.WriteLine($"5's primeiros times: {string.Join(", ",_arrayPrimeirosColocadosCampeonatoBR.Take(5))}.");

        private static void ExibirQuatroUltimosColocados()
            => Console.WriteLine($"4's últimos colocados: {string.Join(", ",_arrayPrimeirosColocadosCampeonatoBR.Skip(_arrayPrimeirosColocadosCampeonatoBR.Length - 4))}.");

        private static void ExibirTimesOrdemAlfabetica()
            => Console.WriteLine($"Times em ordem Alfabética: {string.Join(", ",_arrayPrimeirosColocadosCampeonatoBR.OrderBy(t=>t))}.");

        private static void ExibirPosicaoTimeChapecoense()
            => Console.WriteLine($"O time 'Chapecoense' está localizado na posição {Array.IndexOf(_arrayPrimeirosColocadosCampeonatoBR, "CHAPECOENSE") + 1}ª da lista.");

     
        private static void ExibirPosicaoTimeEscolhido()
        {
            while (true)
            {
                Console.Write("Digite o nome de um time para saber a posição: ");
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

                Console.Clear();
                Console.WriteLine($"O time '{timeEscolhido}' está localizado na posição {Array.IndexOf(_arrayPrimeirosColocadosCampeonatoBR, timeEscolhido) + 1}ª da lista.");
                break;
            }
        }

        private static void ExibirMenu() 
        {
            Console.WriteLine(@"
1 - Os 5 primeiros times.
2 - Os últimos 4 colocados.
3 - Times em ordem alfabética. 
4 - Em que posição está o time da Chapecoense.
5 - Escolha um time para saber a posição
6 - Sair
");
        }

        private static void EscolherOpcaoMenu()
        {
            while (true)
            {
                int escolha;
                ExibirMenu();
                while (true)
                {
                    Console.Write("Digite o número da opção desejada: ");
                    string entrada = Console.ReadLine().Trim();
                    if(!int.TryParse(entrada, out escolha) || escolha < 1 || escolha > 6)
                    {
                        Console.Clear();
                        ExibirMenu();
                        Console.WriteLine("Entrada inválida. Por favor, digite um número entre 1 e 6.");
                        continue;
                    }
                    break;
                }

                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        ExibirCincoPrimeirosTimes();
                        break;
                    case 2:
                        Console.Clear();
                        ExibirQuatroUltimosColocados();
                        break;
                    case 3:
                        Console.Clear();
                        ExibirTimesOrdemAlfabetica();
                        break;
                    case 4:
                        Console.Clear();
                        ExibirPosicaoTimeChapecoense();
                        break;
                    case 5:
                        Console.Clear();
                        ExibirPosicaoTimeEscolhido();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Saindo do programa. Obrigado por usar!");
                        return;
                }
            }
        }
        private static void ExibirDados()
            =>EscolherOpcaoMenu();
    }
}
