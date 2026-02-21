using BtgApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BtgApi.Data.Map
{
    public class ProdutoFinanceiroMap : IEntityTypeConfiguration<ProdutoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<ProdutoFinanceiro> builder)
        {
            //Atribuir valores[ID] às propriedades

            builder.HasData(
                new ProdutoFinanceiro("Certificado de Depósito Bancário") {ProdutoFinanceiroID = 1}, 
                new ProdutoFinanceiro("Fundos de Investimento") { ProdutoFinanceiroID = 2 },
                new ProdutoFinanceiro("Ações") { ProdutoFinanceiroID = 3 }
                );
        }
    }
}
