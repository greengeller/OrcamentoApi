using Microsoft.EntityFrameworkCore;
using OrcamentoApi.Models;

namespace OrcamentoApi.Data
{
    public class OrcamentoContext : DbContext
    {
        public OrcamentoContext(DbContextOptions<OrcamentoContext> opt) : base(opt)
        {
        }
        public DbSet<Orcamento> Orcamento { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Produtos>()
            //    .HasOne(p => p.Orcamento);
            //    //.HasKey(t => t.Id)


            //    HasKey(t => t.Id);

            modelBuilder.Entity<Orcamento>()
                .ToTable("Orcamentos");

            modelBuilder.Entity<Orcamento>()
                .HasOne(orcamento => orcamento.Vendedor);

            modelBuilder.Entity<Orcamento>()
                 .HasOne(orcamento => orcamento.Produtos);           

        }
    }
}

