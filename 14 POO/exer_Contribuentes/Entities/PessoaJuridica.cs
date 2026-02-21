using System.Text;
using treino.Entities.Enums;


namespace treino.Entities
{
    internal class PessoaJuridica : Contribuentes
    {
        public int QuantidadeFuncionarios{ get; set; }
        public PessoaJuridica(int quantidadeFuncionarios, string nome, decimal rendaMensal) : base(nome, rendaMensal)
        {
            QuantidadeFuncionarios = quantidadeFuncionarios;
        }

        public override decimal CalculoImposto() => QuantidadeFuncionarios <= 10 ? RendaMensal * 0.16m : RendaMensal * 0.14m;

        public override string ToString()
        {
            decimal imposto = CalculoImposto();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pessoa {Tipo.PessoaJuridica}\n" +
                $"Nome: {Nome}\n" +
                $"Renda Mensal: R${RendaMensal:F2}\n" +
                $"Quantidade de Funcionários: {QuantidadeFuncionarios}\n");
            sb.AppendLine(imposto > 0 ? $"Valor do Imposto: {imposto:F2}\n" : "Não há imposto");
            sb.AppendLine("------------------------\n");
            
            return sb.ToString();
        }
    }
}
