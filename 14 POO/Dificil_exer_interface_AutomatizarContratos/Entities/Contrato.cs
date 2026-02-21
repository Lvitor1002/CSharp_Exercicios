using System;
using System.Collections.Generic;


namespace treino.Entities
{
    internal class Contrato
    {
        public int Id{ get; set; }
        public DateTime DataContrato { get; set; } 
        public decimal ValorTotalContrato{ get; set; }
        public List<Parcelas> ListaParcelas { get; set; } = new List<Parcelas>();

        public Contrato(int id, decimal valorTotalContrato)
        {
            Id = id;
            DataContrato =  DateTime.Now;
            ValorTotalContrato = valorTotalContrato;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Número do Contrato: {Id}\n" +
                $"Data do Contrato: {DataContrato.ToString("dd/MM/yyyy")}\n" +
                $"Valor Total do Contrato: {ValorTotalContrato:F2}\n" +
                $"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            return sb.ToString();
        }
    }
}
