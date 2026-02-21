using EstudoApiTeste.Data.Map;
using EstudoApiTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudoApiTeste.Data
{
    public class EstudoDB : DbContext
    {
        public EstudoDB(DbContextOptions<EstudoDB> options) : base(options)
        {
        }

        public DbSet<ProdutoModels> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
