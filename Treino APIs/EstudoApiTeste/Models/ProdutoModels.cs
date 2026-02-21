namespace EstudoApiTeste.Models
{
    public class ProdutoModels
    {
        public int Id{ get; set; }
        public string Nome{ get; set; } = string.Empty;
        public double Preco{ get; set; }
        public DateTime DataVenda{ get; set; } = DateTime.Now;
    }
}
