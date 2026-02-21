

/*
Ler os dados de um [pedido]:
                            InstantePedido,
                            Status,
                            Quantidade de Itens. 

com [N itens] (N fornecido pelo usuário) considerando os seus atributos; nome, 
                                                                        unidades, 
                                                                        preco. 

Depois, mostrar um sumário do pedido; 
                                    instante do pedido, 
                                    Status do Pedido, 
                                    cliente(Nome, email, dt nascimento),
                                    itens do pedido,
                                    preço total.

Nota: o instante do pedido deve ser o instante do sistema: DateTime.Now
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        public static List<Pedido> Leitura()
        {
            var listaPedidos = new List<Pedido>();
            
            int qtdPedidos = 0, qtdItens = 0, qtdUnidadesItem = 0;
            
            Status status;

            string nomeCliente, emailCliente, nomeItem;
            
            DateTime dataNascimentoCliente;
            
            decimal precoItem;

            while (true)
            {
                Console.Write("Digite a quantidade de pedidos ao todo: ");
                string qtdP = Console.ReadLine().Trim();
                if(!int.TryParse(qtdP, out qtdPedidos) || qtdPedidos <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                    continue;
                }
                break;
            }
            for(int i =0; i<qtdPedidos; i++)
            {
                Console.Clear();
                Console.Write($"\t   {i+1}ª Pedido\n\n");

                //Sorteio do status para ser aleatório:
                var valores = Enum.GetValues(typeof(Status));
                Random random = new Random();

                status = (Status)valores.GetValue(random.Next(valores.Length));

                while (true)
                {
                    Console.Write("Digite o nome do cliente: ");
                    nomeCliente = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(nomeCliente) || !nomeCliente.All(c=>char.IsLetter(c) || c==' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um nome válido!");
                        continue;
                    }
                    nomeCliente = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomeCliente.ToLower());
                    break;
                }
                while (true)
                {
                    Console.Write($"Digite o email de {nomeCliente}: ");
                    emailCliente = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(emailCliente)
                        || !emailCliente.Contains("@")
                        || !emailCliente.Contains(".")
                        || emailCliente.StartsWith("@")
                        || emailCliente.EndsWith("@")
                        || emailCliente.StartsWith(".")
                        || emailCliente.EndsWith("."))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um email válido. Ex: 'nome@gmail.com'");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write($"Digite a data de nascimento de {nomeCliente}: [dd/mm/aaaa] ");
                    string dataN = Console.ReadLine().Trim();
                    if (!DateTime.TryParse(dataN, out dataNascimentoCliente))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite uma data válida: [dd/mm/aaaa]!");
                        continue;
                    }
                    break;
                }

                Cliente cliente = new Cliente(nomeCliente, emailCliente, dataNascimentoCliente);

                Pedido pedido = new Pedido(status, cliente);

                Console.Clear();
                while (true)
                {
                    Console.Write($"Digite a quantidade de itens ao todo do {i+1}ª Pedido: ");
                    string qtdI = Console.ReadLine().Trim();
                    if (!int.TryParse(qtdI, out qtdItens) || qtdItens < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior ou igual há zero!");
                        continue;
                    }
                    break;
                }

                for (int itm = 0; itm < qtdItens; itm++)
                {
                    Console.Clear();
                    Console.Write($"\t   {itm + 1}ª Item\n\n");

                    while (true)
                    {
                        Console.Write("Digite o nome do Item: ");
                        nomeItem = Console.ReadLine().Trim().ToLower();
                        if (string.IsNullOrWhiteSpace(nomeItem) || !nomeItem.All(c => char.IsLetter(c) || c == ' '))
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Digite um nome válido!");
                            continue;
                        }
                        nomeItem = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomeItem.ToLower());
                        break;
                    }
                    while (true)
                    {
                        Console.Write($"Digite a quantidade de unidade deste item: ");
                        string qtdU = Console.ReadLine().Trim();
                        if (!int.TryParse(qtdU, out qtdUnidadesItem) || qtdUnidadesItem < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior ou igual há zero!");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.Write($"Digite o preço do item: R$");
                        string precoI = Console.ReadLine().Trim();
                        if (!decimal.TryParse(precoI, out precoItem) || precoItem <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' maior que zero!");
                            continue;
                        }
                        break;
                    }

                    Item item = new Item(nomeItem,qtdUnidadesItem,precoItem);

                    pedido.AddItens(item);
                }

                listaPedidos.Add(pedido);
            }
            return listaPedidos;
        }
        public static void Exibir()
        {
            var listaPedidos = Leitura();

            Console.Clear();
            foreach(var p in listaPedidos) 
            {
                Console.WriteLine(p.ToString());   
            }
        }
    }
}
