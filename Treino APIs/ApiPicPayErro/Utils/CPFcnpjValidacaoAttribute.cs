using System.ComponentModel.DataAnnotations;

namespace BackEndPicPay.Utils
{
    public class CPFcnpjValidacaoAttribute : ValidationAttribute
    {
        // Sobrescreve o método central de validação
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cpfcnpj = value as string;

            if (string.IsNullOrEmpty(cpfcnpj) || !CPFcnpjValidacao.CPFcnpjValido(cpfcnpj))
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
