using System.ComponentModel.DataAnnotations;
using BackEndPicPay.Models.Enum;

namespace BackEndPicPay.Models
{

    //Classe criada para atender aos dois usuários
    public class Carteira
    {

        [Key]
        public int IdCarteira{ get; set; }
        public TipoUsuario Tipo { get; set; } 
        [Required][StringLength(50)] public string NomeCompleto { get; set; } 
        [Required]public string CPFcnpj { get; set; } 
        [Required][EmailAddress][StringLength(100)] public string Email{ get; set; } 
        [Required][StringLength(10)] public string Senha{ get; set; } 
        public decimal SaldoConta { get; set; } = 0;

        private Carteira() 
        {
        }
        public Carteira(TipoUsuario tipo, string nomeCompleto, string cpfcnpj, string email, string senha, decimal saldoConta = 0)
        {
            Tipo = tipo;
            NomeCompleto = nomeCompleto;
            CPFcnpj = cpfcnpj;
            Email = email;
            Senha = senha;
            SaldoConta = saldoConta;
        }

        public void DebitarSaldo(decimal valor)
        {
            SaldoConta -= valor;
        }
        public void CreditarSaldo(decimal valor)
        {
            SaldoConta += valor;
        }
    }
}
