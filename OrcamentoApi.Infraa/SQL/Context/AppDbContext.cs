using Microsoft.EntityFrameworkCore;
using OrcamentoApi.Domain.Models;

namespace OrcamentoApi.Infra.SQL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);                        

            modelBuilder.Entity<Orcamento>()
                .HasOne(orcamento => orcamento.Vendedor);

            modelBuilder.Entity<Orcamento>()
                 .HasOne(orcamento => orcamento.Produtos);       
        }
    }
}

