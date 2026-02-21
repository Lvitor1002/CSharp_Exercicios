using BtgApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BtgApi.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasData(
                new Cliente(clienteID: 1, "Luiz Cliente 1"),
                new Cliente(clienteID:2, "Pedro Cliente 2"),
                new Cliente(clienteID: 3, "Joice Cliente 3")
                );
        }
    }
}
