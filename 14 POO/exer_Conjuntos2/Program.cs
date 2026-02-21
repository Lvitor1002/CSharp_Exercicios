

/*
Na contagem de votos de uma eleição, são gerados vários registros de votação contendo; 
                                                                                     o nome do candidato,
                                                                                     quantidade de votos(formato .csv) 
que ele obteve em uma urna de votação. 

Você deve fazer um programa para ler os registros de votação a partir de um arquivo, 
e daí gerar um relatório consolidado com os totais de cada candidato.

 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using treino.Entities;


namespace treino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        public static HashSet<Registros> Leitura()
        {
            var listaRegistros = new HashSet<Registros>();

            Console.Write("Entre com o caminho do arquivo: "); //C:\Users\Luiz\Desktop\csharp\Treino APIs\treino\log.txt

            string arquivo = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(arquivo))
                {
                    while(!sr.EndOfStream)
                    {
                        string[] registroVotos = sr.ReadLine().Split(',');
                        string nome = registroVotos[0].Trim();
                        int qtd = int.Parse(registroVotos[1].Trim());

                        Registros registro = new Registros(nome, qtd);
                        Registros candidatoExistente;

                        //acumular votos quando um registro duplicado é encontrado.
                        if (listaRegistros.TryGetValue(registro, out candidatoExistente))
                        {
                            candidatoExistente.AdicionaVotos(qtd);
                        }
                        else
                        {
                            listaRegistros.Add(registro);
                        }

                    }
                }
            }
            catch (Exception ex) 
            {
                Console.Clear();
                Console.WriteLine($"Erro ao ler arquivo: {ex.Message}");
            }
            return listaRegistros;
        }
        public static void Exibir()
        {
            HashSet<Registros> listaRegistros = Leitura();

            Console.Clear();
            //relatório consolidado com os totais de cada candidato
            Console.WriteLine("Relatório consolidado de votos:\n");
            Console.WriteLine($"{listaRegistros.Count} candidatos distintos\n");

            // Ordena por votos (decrescente)
            var relatorio = listaRegistros.OrderByDescending(x=>x.Quantidade).ToList(); 

            foreach(var registro in listaRegistros)
            {
                Console.WriteLine($"{registro.Nome}: {registro.Quantidade} votos");
            }
        }
    }
}
