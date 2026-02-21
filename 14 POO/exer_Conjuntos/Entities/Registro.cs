using System;

namespace treino.Entities
{
    internal class Registro
    {
        public string NomeUsuario{ get; set; }
        public DateTime InstanteAcessso{ get; set; }

        public Registro(string nomeUsuario, DateTime instanteAcessso)
        {
            NomeUsuario = nomeUsuario;
            InstanteAcessso = instanteAcessso;
        }

        public override int GetHashCode() => NomeUsuario.GetHashCode(); //Pegando um identificar(código) para o usuário

        public override bool Equals(object obj)
        {
            if(!(obj is Registro)) return false;

            Registro outroRegistro = obj as Registro;

            // Quando que o [NomeUsuario] será igual ao outro objeto?
            return NomeUsuario.Equals(outroRegistro.NomeUsuario);
        }
    }
}
