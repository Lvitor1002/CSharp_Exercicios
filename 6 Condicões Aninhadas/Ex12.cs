// Usando switch case com arrays


using System;


namespace Etapa1
{
    public class Program
    {
        public static void Main(string[] args)
            => UsandoSwitchCase();

        private static void UsandoSwitchCase()
        {
            string sku = "01-MN-L";

            string[] produto = sku.Split('-');
            string tipo = "", cor = "", tamanho = "";

            switch (produto[0])
            {
                case string p when p.Contains("01"):
                    tipo = "Sweat shirt";
                    break;
                case string p when p.Contains("02"):
                    tipo = "T-Shirt";
                    break;
                case string p when p.Contains("03"):
                    tipo = "Sweat pants";
                    break;
                default:
                    tipo = "Other";
                    break;
            }

            switch (produto[1])
            {
                case string p when p.Contains("BL"):
                    cor = "Black";
                    break;
                case string p when p.Contains("MN"):
                    cor = "Maroon";
                    break;
                default:
                    cor = "White";
                    break;
            }

            switch (produto[2])
            {
                case string p when p.Contains("S"):
                    tamanho = "Small";
                    break;
                case string p when p.Contains("M"):
                    tamanho = "Medium";
                    break;
                case string p when p.Contains("L"):
                    tamanho = "Large";
                    break;
                default:
                    tamanho = "One size Fits all";
                    break;
            }

            Console.WriteLine($"Produto: {tamanho} {cor} {tipo}");
        }
    }
}

