
namespace treino.Entities
{
    internal class Comentario
    {
        public string Descricao { get; set; }
        public Comentario(string descricao) => Descricao = descricao;

        public override string ToString()
        {
            return $"\t\t {Descricao}";
        }
    }
}
