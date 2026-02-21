using BtgApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BtgApi.Data.Map
{
    public class ResgateMap : IEntityTypeConfiguration<Resgate>
    {
        public void Configure(EntityTypeBuilder<Resgate> builder)
        {
            builder.HasOne(x => x.ProdutoFinanceiro)
                .WithMany(x => x.ListaResgates)
                .HasForeignKey(x => x.ResgateID);

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.ListaResgates)
                .HasForeignKey(x => x.ClienteID);

            builder.Property(x => x.ImpostoRenda)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ValorResgate)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ValorLiquidoIR)
                .HasColumnType("decimal(18,2)");
        }
    }
}
