using BtgApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BtgApi.Data.Map
{
    public class AplicacaoMap : IEntityTypeConfiguration<Aplicacao>
    {
        public void Configure(EntityTypeBuilder<Aplicacao> builder)
        {

            builder.HasOne(x => x.ProdutoFinanceiro)
                .WithMany(x => x.ListaAplicacoes)
                .HasForeignKey(x => x.ProdutoFinanceiroID);


            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.ListaAplicacoes)
                .HasForeignKey(x => x.ClienteID);


            builder.Property(x => x.Valor)
                .HasColumnType("decimal(18,2)");

        }
    }
}
