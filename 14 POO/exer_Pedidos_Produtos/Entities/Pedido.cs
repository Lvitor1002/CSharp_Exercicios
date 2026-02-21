using System;
using System.Collections.Generic;
using System.Text;
using treino.Entities.Enums;

namespace treino.Entities
{
    internal class Pedido
    {
        public DateTime InstantePedido { get; set; }
        public Status Status { get; set; }
        public int QuantidadeItens{ get; set; }
        public List<Item> ListaItens { get; set; } = new List<Item>();
        public Cliente Cliente{ get; set; }

        public Pedido(Status status, Cliente cliente)
        {
            InstantePedido = DateTime.Now;
            Status = status;
            Cliente = cliente;
        }

        public void AddItens(Item item)
        {
            ListaItens.Add(item);
        }

        public decimal ValorTotal()
        {
            decimal soma = 0;

            foreach (var item in ListaItens) {
                soma += item.SubTotal();
            }
            return soma;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n\t     Sumário do pedido\n");
            sb.Append($"\nInstante do pedido: {InstantePedido.ToString("dd/MM/yyyy HH:mm:ss")}\n" +
                $"Status do Pedido: {Status}\n" +
                $"Nome do Cliente: {Cliente.Nome}\n" +
                $"Email do Cliente: {Cliente.Email}\n" +
                $"Data de nascimento do Cliente: {Cliente.DataNascimento.ToString("dd/MM/yyyy")}\n" +
                $"Preço total: R${ValorTotal():F2}\n" +
                $"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");

            sb.AppendLine(">Lista de Itens para o pedido");
            foreach (var i in ListaItens) {
                sb.Append(i.ToString());
            }
            return sb.ToString();
        }
    }
}
