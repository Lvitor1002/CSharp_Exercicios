using System.ComponentModel.DataAnnotations;

namespace BackEndPicPay.Models.Requests
{
    public class TransferenciaRequest
    {
        //Pedido que o cliente (ex: navegador, app, frontend) envia para o servidor.

        [Required(ErrorMessage = "O campo valor é obrigatório.")]
        public decimal Valor { get; set; }


        [Required(ErrorMessage = "O campo EnviarId é obrigatório.")]
        public int EnviarId { get; set; }


        [Required(ErrorMessage = "O campo ReceberId é obrigatório.")]
        public int ReceberId { get; set; }
    }
}
