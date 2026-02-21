using System;


namespace treino.Entities
{
    internal class Parcelas
    {
        public DateTime DataVencimento { get; set; }
        public decimal ValorParcela{ get; set; }

        public Parcelas(DateTime dataParcela, decimal valorParcela)
        {
            DataVencimento = dataParcela;
            ValorParcela = valorParcela;
        }
        public override string ToString()
        {
            return $">Data de Vencimento: {DataVencimento.ToString("dd/MM/yyyy")}\n" +
                $">Valor da parcela: {ValorParcela:F2}\n\n";
        }
    }
}
