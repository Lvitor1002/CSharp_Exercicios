using ApiEcommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiEcommerce.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("VARCHAR").HasMaxLength(100);
            builder.Property(x => x.Fabricante).IsRequired().HasColumnType("VARCHAR").HasMaxLength(100);
            builder.Property(x=>x.PrecoUnitario).IsRequired();
            builder.Property(x => x.Desconto).IsRequired();
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.DataExpiracao).IsRequired();
        }
    }
}

