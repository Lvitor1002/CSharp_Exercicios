
/*
Instancie manualmente os objetos mostrados na imagem e mostre-os na tela do
terminal, conforme exemplo:

                       Post:
                            21/06/2018 13:05:44
                            Viajando para a Nova Zelândia
                            Vou visitar esse país maravilhoso!
                            12 curtidas    
                Comentários:
                            Tenham uma boa viagem
                            Uau, isso é demais!
                            
        ----------------------------------------------------
                       Post:
                            28/07/2018 23:14:19                            
                            Boa noite, pessoal
                            Até amanhã
                            5 curtidas
                Comentários:
                            Boa noite
                            Que a Força esteja com vocês
*/


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using treino.Entities;




namespace TREINO
{
    class Program
    {
        static void Main() => Exibir();
        public static List<Post> Leitura()
        {
            string tituloPost, descPost, descricao;
            int quantidadeCurtida, qtdPost, qtdComentarios;
            var listaPosts = new List<Post>();

            while (true)
            {
                Console.Write("Digite a quantidade de Post ao todo: ");
                string qtdP = Console.ReadLine().Trim();
                if(!int.TryParse(qtdP, out qtdPost) || qtdPost <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' positivo e maior que zero!");
                    continue;
                }
                break;
            }

            for(int p = 0; p<qtdPost; p++)
            {
                Console.Clear();
                Console.WriteLine($"\t  {p+1}ª Post");

                while (true)
                {
                    Console.Write($"Digite um título para o {p+1}ª Post: ");
                    tituloPost = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(tituloPost))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um título válido");
                        continue;
                    }
                    tituloPost = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tituloPost.ToLower());
                    break;
                }
                while (true)
                {
                    Console.Write($"Digite uma descrição para o {p + 1}ª Post: ");
                    descPost = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(descPost))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com uma descrição válido");
                        continue;
                    }
                    descPost = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(descPost.ToLower());
                    break;
                }
                while (true)
                {
                    Console.Write($"Digite a quantidade de curtidas para o {p + 1}ª Post: ");
                    string qtdC = Console.ReadLine().Trim();
                    if (!int.TryParse(qtdC, out quantidadeCurtida) || quantidadeCurtida <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' positivo e maior que zero!");
                        continue;
                    }
                    break;
                }
                Post post = new Post(tituloPost, descPost, quantidadeCurtida);
                listaPosts.Add(post);

                while (true)
                {
                    Console.Write($"Digite a quantidade de comentários ao todo para o {p + 1}ª Post: ");
                    string qtdC = Console.ReadLine().Trim();
                    if (!int.TryParse(qtdC, out qtdComentarios) || qtdComentarios <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' positivo e maior que zero!");
                        continue;
                    }
                    break;
                }

                for (int c = 0; c < qtdComentarios; c++)
                {
                    Console.Clear();
                    Console.WriteLine($"\t  {c + 1}ª Comentário");

                    while (true)
                    {
                        Console.Write($"Digite uma descrição para o {c + 1}ª Comentário: ");
                        descricao = Console.ReadLine().Trim().ToLower();
                        if (string.IsNullOrWhiteSpace(descricao))
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com uma descrição válido");
                            continue;
                        }
                        descricao = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(descricao.ToLower());
                        break;
                    }
                    post.AddComentario(new Comentario(descricao));
                }

            }
            return listaPosts;
        }
        public static void Exibir()
        {
            var listaPosts = Leitura();
            
            Console.Clear();

            Console.WriteLine("\t   Lista de Postagem\n");
            foreach(var p  in listaPosts) 
                Console.WriteLine(p.ToString());
        }
    }
}

