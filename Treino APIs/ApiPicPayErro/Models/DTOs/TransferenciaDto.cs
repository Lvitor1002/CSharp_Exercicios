namespace BackEndPicPay.Models.DTOs
{
    public record TransferenciaDto(Guid IdTransaction, 
                                        Carteira Enviar, 
                                        Carteira Receber, 
                                        decimal ValorTransferido);
}
