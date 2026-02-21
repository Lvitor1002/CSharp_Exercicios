
/*
Uma empresa possui funcionários próprios e terceirizados.
Para cada funcionário, deseja-se registrar; 
                                            nome, 
                                            horas trabalhadas,
                                            valor por hora, considerando que os mesmos trabalham 30 dias.. 
                

Funcionários terceirizados possuem ainda uma despesa adicional.
O pagamento dos funcionários terceirizados corresponde ao (valor da hora trabalhadas multiplicado pelas dias trabalhados), 
sendo que os funcionários terceirizados ainda recebem um bônus correspondente a 110% de sua despesa adicional.

Faça um programa para ler os dados de N funcionários (N fornecido pelo usuário) e armazená-los em uma lista. 

Depois de ler todos os dados, 
                            mostrar nome,
                            pagamento mensal de cada funcionário,

na mesma ordem em que foram digitados.
 
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using treino.Entities;
using treino.Entities.Enums;



namespace treino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        public static List<Funcionario> Leitura()
        {
            Tipo tipo;
            int qtdFuncionarios;
            var listaFuncionarios = new List<Funcionario>();

            string nome;
            int horasTrabalhadas;
            double salarioHora, despesa;

            while (true)
            {
                Console.Write("Entre com o total de funcionarios: ");
                string qtdF = Console.ReadLine().Trim();
                if(!int.TryParse(qtdF, out qtdFuncionarios) || qtdFuncionarios <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                    continue;
                }
                break;
            }

            for (int i = 0; i < qtdFuncionarios; i++)
            {
                Console.Clear();
                Console.WriteLine($"{i + 1}ª Funcionário");

                while (true)
                {
                    Console.Write("É funcionário [Proprio ou Terceiro]? ");
                    string tipoF = Console.ReadLine().Trim();
                    if (!Enum.TryParse<Tipo>(tipoF, true, out tipo))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite uma das opções a seguir: [Proprio ou Terceiro]");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.Write($"Entre com o nome do funcionario {tipo}: ");
                    nome = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c=> char.IsLetter(c) || c == ' '))
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
                    Console.Write($"Entre com as horas trabalhadas por dia do funcionario {nome}: ");
                    string horasT = Console.ReadLine().Trim();
                    if (!int.TryParse(horasT, out horasTrabalhadas) || horasTrabalhadas <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.Write($"Entre com valor recebido por hora do funcionario {nome}: R$ ");
                    string valorH = Console.ReadLine().Trim();
                    if (!double.TryParse(valorH, out salarioHora) || salarioHora <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' maior que zero!");
                        continue;
                    }
                    break;
                }

                if (tipo == Tipo.Proprio)
                {
                    listaFuncionarios.Add(new Funcionario(nome,horasTrabalhadas,salarioHora));
                }

                if(tipo == Tipo.Terceiro)
                {
                    while (true)
                    {
                        Console.Write($"Entre com valor de despesa do funcionario {nome}: R$ ");
                        string despesaF = Console.ReadLine().Trim();
                        if (!double.TryParse(despesaF, out despesa) || despesa < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' maior ou igual há zero!");
                            continue;
                        }
                        break;
                    }
                    listaFuncionarios.Add(new FuncionarioTercerizado(despesa, nome, horasTrabalhadas, salarioHora));
                }
            }
            return listaFuncionarios;
        }
        public static void Exibir()
        {
            var listaFuncionarios = Leitura();

            Console.Clear();
            foreach(var f in listaFuncionarios)
            {
                Console.WriteLine(f.ToString());
            }
        }
    }
}
