using System;


namespace treino.Entities
{
    internal class Item
    {
        public string Nome{ get; set; }
        public int Unidades{ get; set; }
        public Decimal Preco{ get; set; }

        public Item(string nome, int unidades, decimal preco)
        {
            Nome = nome;
            Unidades = unidades;
            Preco = preco;
        }
        public decimal SubTotal()
        {
            return Unidades * Preco;
        }

        public override string ToString()
        {
            return $"\nNome do Item: {Nome}\n" +
                $"Quantidade de Unidades: {Unidades}\n" +
                $"Preço do Item: {Preco:F2}\n" +
                $"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n";
        }

    }
}
