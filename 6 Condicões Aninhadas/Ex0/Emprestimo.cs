

namespace Fundamentos
{
    public class Emprestimo
    {
        public decimal ValorCasa { get; set; }
        public decimal SalarioComprador { get; set; }
        public int AnosPagamento { get; set; }

        public Emprestimo(decimal valorCasa, decimal salarioComprador, int anosPagamento)
        {
            ValorCasa = valorCasa;
            SalarioComprador = salarioComprador;
            AnosPagamento = anosPagamento;
        }

        public decimal CalcularPrestacao()
            => ValorCasa / (AnosPagamento * 12);

        public bool EmprestimoAprovado()
            => CalcularPrestacao() <= SalarioComprador * 0.3m;

        public override string ToString()
            => $@"
Valor da casa: {ValorCasa:C2}
Salário do comprador: {SalarioComprador:C2}
Anos para pagamento: {AnosPagamento} anos
Valor da prestação mensal: {(EmprestimoAprovado() ? CalcularPrestacao().ToString("C2") : "Empréstimo negado! A mesma excedeu 30% do salário")}
";
    }
}
