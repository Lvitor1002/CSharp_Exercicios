
/*
Fazer um programa em design [Herança junto com Interface] e ler primeiramente a quantidade de figuras ao todo, 
depois os dados de cada N figuras (N fornecido pelo usuário);
                                                                Retângulo ou Círculo?
                                                if == Retângulo:
                                                                Cor[preto,azul,vermelho]:,
                                                                Largura:,
                                                                Altura:,
                                                if == Círculo:
                                                                Cor[preto,azul,vermelho]:,
                                                                Raio:
e depois mostrar as áreas destas figuras na mesma ordem em que foram digitadas.
 */



using System;
using System.Collections.Generic;
using System.Globalization;
using treino.Entities;
using treino.Entities.Enums;




namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();
        static public List<Figura>  Leitura()
        {
            var ListaFiguras = new List<Figura>();
            int qtdFiguras;
            Cor cor;
            string op;
            double raio;
            decimal largura, altura;

            while (true)
            {
                Console.Write("Quantas figuras serão cadastradas? ");
                string qtdF = Console.ReadLine().Trim();
                if(!int.TryParse(qtdF, out qtdFiguras) || qtdFiguras <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' positivo maior que zero!");
                    continue;
                }
                break;
            }
            for (int i = 0; i < qtdFiguras; i++) {
                Console.Clear();
                Console.WriteLine($"\t  {i+1}ª Figura\n");
                while (true)
                {
                    Console.Write("Círculo ou Retângulo? ");
                    op = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(op))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite Circulo ou Retangulo!");
                        continue;
                    }
                    
                    break;
                }
                while (true)
                {
                    Console.Write($"Escolha uma cor para {op}: [Preto | Azul | Vermelho] ");
                    string corF = Console.ReadLine().Trim();
                    if (!Enum.TryParse<Cor>(corF, true, out cor))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com uma das cores: [Preto | Azul | Vermelho]\n");
                        continue;
                    }
                    break;
                }
                if (op == "circulo")
                {
                    while (true)
                    {
                        Console.Write($"Digite o raio do {op}: ");
                        string raioC = Console.ReadLine().Trim();
                        if (!double.TryParse(raioC, out raio) || raio <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' ou 'real' positivo maior que zero!");
                            continue;
                        }
                        break;
                    }
                    Circulo circulo = new Circulo(raio, cor);
                    circulo.AreaFigura();
                    ListaFiguras.Add(circulo);
                }
                if (op == "retangulo")
                {
                    while (true)
                    {
                        Console.Write($"Digite a largura do {op}: ");
                        string larguraR = Console.ReadLine().Trim();
                        if (!decimal.TryParse(larguraR, out largura) || largura <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' ou 'real' positivo maior que zero!");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.Write($"Digite a altura do {op}: ");
                        string alturaR = Console.ReadLine().Trim();
                        if (!decimal.TryParse(alturaR, out altura) || altura <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' ou 'real' positivo maior que zero!");
                            continue;
                        }
                        break;
                    }
                    Retangulo retangulo = new Retangulo(largura, altura, cor);
                    retangulo.AreaFigura();
                    ListaFiguras.Add(retangulo);
                }
            }
            return ListaFiguras;
        }
        public static void Exibir()
        {
            var lista = Leitura();

            Console.Clear();
            foreach (var item in lista) 
                Console.WriteLine(item.ToString());
        }
    }
}

