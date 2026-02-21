using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace treino.Entities
{
    internal class Registros
    {
        public string Nome { get; set; }
        public int Quantidade{ get; set; }

        public Registros(string nome, int quantidade)
        {
            Nome = nome;
            Quantidade = quantidade;
        }

        public void AdicionaVotos(int voto)
        {
            Quantidade += voto;
        }
        public override int GetHashCode()
        {
            return Nome.GetHashCode();
        }


        public override bool Equals(object obj)
        {
            if(!(obj is Registros))
            {
                return false;
            }

            Registros outro = obj as Registros;
            
            return Nome.Equals(outro.Nome);
        }
    }
}
