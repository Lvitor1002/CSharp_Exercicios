
/*
Um site de internet registra um log de acessos dos usuários. 
Um [registro] de log consiste no; 
                                nome de usuário,
                                instante em que ousuário acessou o site no padrão ISO 8601, separados por espaço.

Fazer um programa que leia o log de acessos apartir de um arquivo, e daí informe quantos usuários do arquivo que são distintos acessaram o site.
 
Arquivo: C:\Users\Luiz\Desktop\c#\13 POO\14 POO Avançado\exer_Conjuntos\in.txt
 */



using System;
using System.Collections.Generic;
using System.IO;

using treino.Entities;




namespace TREINO
{
    class Program
    {
        static void Main()
        {
            Exibir();
        }
        public static HashSet<Registro> Leitura()
        {
            //HashSet - Usado para distinguir na contagem os usuários únicos, distintos 
            HashSet<Registro> registros = new HashSet<Registro>();  
            string arquivo;
            
            while (true)
            {
                Console.Write("Entre com o caminho do arquivo: ");
                arquivo = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(arquivo))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Tente novamente!");
                    continue;
                }
                break;
            }
            try
            {
                using(StreamReader sr = File.OpenText(arquivo))
                {
                    string[] dividido = sr.ReadLine().Split(' ');
                    string nomeUsuario = dividido[0];
                    DateTime instanteAcessso = DateTime.Parse(dividido[1]);

                    registros.Add(new Registro(nomeUsuario, instanteAcessso));
                }
            }
            catch (Exception ex) 
            {
                Console.Clear();
                Console.WriteLine($"{ex.Message}");
            }
            return registros;
        }
        public static void Exibir()
        {
            var registros = Leitura();

            Console.Clear();
            //quantos usuários do arquivo que são distintos acessaram o site. O próprio HasSet distingue os dados
            Console.WriteLine($"{registros.Count} Usuários distintos.\n\n\n");
        }
    }
}

