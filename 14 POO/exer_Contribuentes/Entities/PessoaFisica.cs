using System.Text;
using treino.Entities.Enums;


namespace treino.Entities
{
    internal class PessoaFisica : Contribuentes
    {
        public decimal GastoComSaude{ get; set; }

        public PessoaFisica(decimal gastoComSaude, string nome, decimal rendaMensal) : base(nome, rendaMensal)
        {
            GastoComSaude = gastoComSaude;
        }

        //Para evitar imposto negativo, ajuste o método para retornar 0 quando o resultado for negativo:
        public override decimal CalculoImposto()
        {
            decimal impostoBruto = RendaMensal < 20000 ? RendaMensal * 0.15m : RendaMensal * 0.25m;
            decimal abatimento = GastoComSaude * 0.5m;
            decimal impostoLiquido = impostoBruto - abatimento;
            return impostoLiquido < 0 ? 0 : impostoLiquido;
        }

        public override string ToString()
        {
            decimal imposto = CalculoImposto();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pessoa {Tipo.PessoaFisica}\n" +
                $"Nome: {Nome}\n" +
                $"Renda Mensal: R${RendaMensal:F2}\n");

            sb.AppendLine(GastoComSaude > 0 ? $"Gasto com Saude: R${GastoComSaude:F2}\n" : "Não houve gasto com saúde!");
            sb.AppendLine(imposto > 0 ? $"Valor do Imposto: {imposto:F2}\n" : "Não há imposto!");
            sb.AppendLine($"------------------------\n");

            return sb.ToString();
        }
    }
}
