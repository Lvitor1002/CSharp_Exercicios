
namespace treino.Entities
{
    internal class FuncionarioTercerizado : Funcionario
    {
        public double Despesa { get; set; }

        public FuncionarioTercerizado(double despesa,string nome, int horasTrabalhadas, double salarioHora) : base(nome, horasTrabalhadas, salarioHora)
        {
            Despesa = despesa;
        }

        public override double Pagamento()
        {
            return base.Pagamento() + (Despesa * 1.10); // Bônus de 110%
        }

        public override string ToString()
        {
            return ($"\n'Terceiro'\n\n" +
                $">Nome: {Nome}\n" +
                $">Horas trabalhadas: {HorasPorDia}\n" +
                $">Despesa Adicional: R${Despesa:F2}\n" +
                $">Valor por dia recebido: R${SalarioHora * HorasPorDia:F2}\n" +
                $">Pagamento mensal: R${Pagamento():F2}\n\n");
        }
    }
}
