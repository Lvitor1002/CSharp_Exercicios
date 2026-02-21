using EstudoApiTeste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstudoApiTeste.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModels>
    {
        public void Configure(EntityTypeBuilder<ProdutoModels> builder)
        {
            builder
                .HasKey(x=>x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x=>x.DataVenda)
                .IsRequired();

        }
    }

}
