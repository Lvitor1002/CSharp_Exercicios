using System;
using System.Collections.Generic;
using System.Text;

namespace treino.Entities
{
    internal class Post
    {
        public DateTime DataPost{ get; set; }
        public string TituloPost{ get; set; }
        public string DescricaoPost{ get; set; }
        public int QuantidadeCurtidas { get; set; }
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();

        public Post(string tituloPost, string descricaoPost, int quantidadeCurtidas)
        {
            DataPost = DateTime.Now;
            TituloPost = tituloPost;
            DescricaoPost = descricaoPost;
            QuantidadeCurtidas = quantidadeCurtidas;
        }

        public void AddComentario(Comentario comentario) => Comentarios.Add(comentario);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Data e hora da Postagem: {DataPost.ToString("dd/MM/yyyy HH:mm:ss")}\n\n" +
                $"Descrição da Postagem: '{TituloPost}'\n\n" +
                $"Comentário da Postagem: '{DescricaoPost}'\n\n" +
                $"Quantidade de Curtidas da Postagem: {QuantidadeCurtidas} curtidas\n\n" +
                $"\t    Comentários\n\n");

            foreach (var c in Comentarios)
                sb.AppendLine($"{c.ToString()}\n");
            sb.AppendLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            return sb.ToString();
        }
    }
}
