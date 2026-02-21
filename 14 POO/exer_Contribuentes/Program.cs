/*
Fazer um programa para ler os dados de N contribuintes (N fornecido pelo usuário), 
os quais podem ser pessoa física ou pessoa jurídica,

Os dados de pessoa física são: nome, 
                               renda mensal,
                               gastos com saúde. 
Os dados de pessoa jurídica são: 
                               nome, 
                               renda mensal, 
                               número de funcionários. 

As regras para cálculo de imposto são as seguintes:

Pessoa física: 
             pessoas cuja renda foi abaixo de 20000.00 pagam 15% de imposto. 
             Pessoas com renda de 20000.00 em diante pagam 25% de imposto. 
             Se a pessoa teve gastos com saúde, 50% destes gastos são abatidos no imposto.
Exemplo: uma pessoa cuja renda foi 50000.00 e teve 2000.00 em gastos com saúde, o imposto fica: (50000 * 25%) - (2000 * 50%) = 11500.00

Pessoa jurídica: 
                pessoas jurídicas pagam 16% de imposto. 
                Porém, se a empresa possuir mais de 10 funcionários, ela paga 14% de imposto.
Exemplo: uma empresa cuja renda foi 400000.00 e possui 25 funcionários, o imposto fica: 400000 * 14% = 56000.00

Por fim, exibir; 
                valor do imposto pago por cada um, 
                total de imposto arrecadado.
 */




using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using treino.Entities;
using treino.Entities.Enums;




namespace TREINO
{
    class Program
    {
        static void Main()
        {
            Exibir();
        }
        public static List<Contribuentes> Leitura()
        {
            var contribuentes = new List<Contribuentes>();

            int quantidadeFuncionarios; string nome; decimal rendaMensal;
            decimal gastoComSaude;
            Tipo tipo;

            int qtdContribuentes;

            while (true)
            {
                Console.Write("Entre com a quantidade de contribuntes: ");
                string qtdC = Console.ReadLine().Trim();
                if(!int.TryParse(qtdC, out qtdContribuentes) || qtdContribuentes <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com uma quantidade válida maior que zero.");
                    continue;
                }
                break;
            }
            for (int i = 1; i <= qtdContribuentes; i++) 
            {
                Console.Clear();
                Console.WriteLine($"\t\t  {i}ª ");
                while (true)
                {
                    Console.Write("É pessoa física ou jurídica? Digite 'PessoaFisica' ou 'PessoaJuridica' - ");
                    string tipoP = Console.ReadLine().Trim();
                    if (!Enum.TryParse<Tipo>(tipoP, true,out tipo))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com uma das opções: [PessoaFisica | PessoaJuridica]");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write($"Digite o nome da {tipo}: ");
                    nome = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c=>char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um nome válido!");
                        continue;
                    }
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }
                while (true)
                {
                    Console.Write($"Qual a renda mensal de {nome}? R$");
                    string rendaM = Console.ReadLine().Trim();
                    if (!decimal.TryParse(rendaM, out rendaMensal) || rendaMensal <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com uma quantidade válida maior que zero.");
                        continue;
                    }
                    break;
                }
                if(tipo == Tipo.PessoaJuridica)
                {
                    while (true)
                    {
                        Console.Write($"Qual a quantidade de funcionários para {nome}? ");
                        string quantidadeF = Console.ReadLine().Trim();
                        if (!int.TryParse(quantidadeF, out quantidadeFuncionarios) || quantidadeFuncionarios <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com uma quantidade válida maior que zero.");
                            continue;
                        }
                        contribuentes.Add(new PessoaJuridica(quantidadeFuncionarios, nome, rendaMensal));
                        break;
                    }
                }
                else if(tipo == Tipo.PessoaFisica)
                {
                    while (true)
                    {
                        Console.Write($">{nome}, qual o valor gasto com saúde?\n>Caso contrário digite zero\n");
                        string gastoCS = Console.ReadLine().Trim();

                        if (!decimal.TryParse(gastoCS, out gastoComSaude) || gastoComSaude < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com uma quantidade válida maior ou 'igual' há zero.");
                            continue;
                        }
                        contribuentes.Add(new PessoaFisica(gastoComSaude, nome, rendaMensal));
                        break;
                    }
                }
            }
            return contribuentes;
        }
        public static void Exibir()
        {
            var contribuentes = Leitura();
            Console.Clear();
            Console.WriteLine("Dados Contribuentes\n" +
                "-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            foreach (var c in contribuentes) { 
                Console.Write(c.ToString());
            }
        }
    }
}

