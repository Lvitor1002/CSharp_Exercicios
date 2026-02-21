using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BackEndPicPay.Models.Enum;
using BackEndPicPay.Utils;

namespace BackEndPicPay.Models.Requests
{
    public class CarteiraRequest
    {
        //Pedido que o cliente (ex: navegador, app, frontend) envia para o servidor.

        [Required(ErrorMessage = "O Nome Completo é obrigatório.")]
        public string NomeCompleto { get; set; }



        [Required(ErrorMessage = "O CPF ou CNPJ é obrigatório.")]
        [CPFcnpjValidacao(ErrorMessage = "O CPF ou CNPJ informado é inválido.")]
        public string CPFcnpj { get; set; }



        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email deve ser válido.")]
        public string Email { get; set; }



        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }



        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoUsuario Tipo { get; set; }



        [Required(ErrorMessage = "O Saldo em conta é obrigatório.")]
        public decimal SaldoConta { get; set; }
    }
}
