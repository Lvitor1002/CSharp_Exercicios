using System;
using treino.Entities.Enums;

namespace treino.Entities
{
    public class Circulo : Figura
    {
        public double Raio { get; set; }
        public Circulo(double raio, Cor cor) : base(cor)
        {
            Raio = raio;
        }
        public override decimal AreaFigura() => Convert.ToDecimal(Math.PI * Math.Pow(Raio, 2));

        public override string ToString()
        {
            return $"Cor do Círculo: {Cor}\n" +
                $"Raio: {Raio}\n" +
                $"Área do Círculo: {AreaFigura():F2}\n" +
                $"-=-=-=-=-=-=-=-=-=-=-=-=\n";
        }
    }
}
