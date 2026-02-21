using BackEndPicPay.Models.DTOs;
using BackEndPicPay.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace BackEndPicPay.Models
{
    public class Transferencia
    {
        public Guid IdTransferencia { get; set; }

        public int EnviarId{ get; set; }
        public Carteira Enviar { get; set; } 

        public int ReceberId{ get; set; }
        public Carteira Receber{ get; set; }

        public decimal Valor{ get; set; }


        private Transferencia() 
        { 
        }
        public Transferencia(int enviarId, int receberId, decimal valor ) 
        {
            IdTransferencia = Guid.NewGuid(); //Cria um ID único da transferência.
            EnviarId = enviarId;
            ReceberId = receberId;
            Valor = valor;
        }


        internal TransferenciaDto ToTransferenciaDto(Transferencia transferencia)
        {
            return new TransferenciaDto(
                transferencia.IdTransferencia,
                transferencia.Enviar,
                transferencia.Receber,
                transferencia.Valor
            );
        }
    }
}
