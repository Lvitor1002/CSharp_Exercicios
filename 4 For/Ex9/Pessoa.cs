
namespace Fundamentos
{
    public class Pessoa
    {
        public string Nome{ get; set; }
        public int Idade{ get; set; }
        public string Sexo{ get; set; }

        public Pessoa(string nome, int idade, string sexo)
        {
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
        }
    }
}
