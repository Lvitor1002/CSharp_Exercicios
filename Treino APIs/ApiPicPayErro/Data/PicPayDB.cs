using BackEndPicPay.Data.Map;
using BackEndPicPay.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndPicPay.Data
{
    public class PicPayDB : DbContext
    {
        public PicPayDB(DbContextOptions<PicPayDB> options) : base(options)
        {
        }

        //Tabelas ->>
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarteiraMap());
            modelBuilder.ApplyConfiguration(new TransferenciaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
