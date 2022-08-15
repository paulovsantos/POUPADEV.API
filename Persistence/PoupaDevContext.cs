using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Entities;

namespace POUPADEV.API.Persistence
{
    public class PoupaDevContext : DbContext
    {
        public PoupaDevContext(DbContextOptions<PoupaDevContext> options) 
             : base(options)
        {
    }
     public DbSet<ObjetivoFinanceiro>? Objetivos { get; private set; }
     protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<ObjetivoFinanceiro>(e => {
            e.HasKey(of => of.Id);

            e.Property(of => of.ValorObjetivo)
            .HasColumnType("decimal(18,4)");

            e.HasMany(of => of.Operacoes)
            .WithOne()
            .HasForeignKey(op => op.IdObjetivo)
            .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Operacao>(e => {
            e.HasKey(op => op.Id);
        });

        }
     }
}
