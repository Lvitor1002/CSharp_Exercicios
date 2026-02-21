using BtgApi.Data.Map;
using BtgApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BtgApi.Data
{
    public class BTGDB : DbContext
    {
        //Tabelas
        public DbSet< Aplicacao >Aplicacoes{ get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ProdutoFinanceiro> ProdutosFinanceiros { get; set; }
        public DbSet<Resgate> Resgates{ get; set; }


        public BTGDB(DbContextOptions<BTGDB> options):base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AplicacaoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoFinanceiroMap());
            modelBuilder.ApplyConfiguration(new ResgateMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
