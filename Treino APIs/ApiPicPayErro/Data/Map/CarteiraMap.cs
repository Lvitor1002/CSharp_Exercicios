using System.Reflection.Emit;
using BackEndPicPay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndPicPay.Data.Map
{
    public class CarteiraMap : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> builder) 
        {

            builder.HasIndex(x => new { x.CPFcnpj, x.Email })
                .IsUnique();

            builder.Property(x => x.SaldoConta)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Tipo)
                .HasConversion<string>();
        }
    }
}
