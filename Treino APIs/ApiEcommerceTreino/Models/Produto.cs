namespace ApiEcommerce.Models
{
    public class Produto
    {
        public int Id{ get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
        public double PrecoUnitario{ get; set; }
        public double Desconto { get; set; }
        public int Quantidade{ get; set; }
        public DateTime DataExpiracao { get; set; }
      
    }
}

