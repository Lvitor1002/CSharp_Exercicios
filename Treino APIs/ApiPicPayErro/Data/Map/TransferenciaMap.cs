using System.Reflection.Emit;
using BackEndPicPay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndPicPay.Data.Map
{
    public class TransferenciaMap : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder) 
        {
            builder.HasKey(x =>x.IdTransferencia);

            builder.HasOne(x => x.Enviar)
                .WithMany()
                .HasForeignKey(x => x.EnviarId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transacao_Enviar");

            builder.HasOne(x => x.Receber)
                .WithMany() //pode estar associada a várias Transacoes
                .HasForeignKey(t => t.ReceberId)
                .OnDelete(DeleteBehavior.Restrict) //não permitirá exclusão
                .HasConstraintName("FK_Transacao_Receber");

            builder.Property(x => x.Valor)
                .HasColumnType("decimal(18,2)");
        }
    }
}


