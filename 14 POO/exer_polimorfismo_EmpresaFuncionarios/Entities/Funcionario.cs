
namespace treino.Entities
{
    internal class Funcionario
    {
        public string Nome { get; set; }
        public int HorasPorDia { get; set; }
        public double SalarioHora { get; set; }

        public Funcionario(string nome, int horasTrabalhadas, double salarioHora)
        {
            Nome = nome;
            HorasPorDia = horasTrabalhadas;
            SalarioHora = salarioHora;
        }

        public virtual double Pagamento()
        {
            return (HorasPorDia * SalarioHora) * 30;
        }

        public override string ToString()
        {
            return ($"\n'Próprio'\n\n" +
                $">Nome: {Nome}\n" +
                $">Horas trabalhadas: {HorasPorDia}\n" +
                $">Valor por dia recebido: R${SalarioHora * HorasPorDia:F2}\n" +
                $">Pagamento mensal: R${Pagamento():F2}\n\n");
        }
    }
}
