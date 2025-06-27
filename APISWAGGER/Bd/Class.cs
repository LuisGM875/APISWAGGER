using APISWAGGER.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APISWAGGER.Bd
{
    public class CalculadoraContext : DbContext
    {
        public CalculadoraContext(DbContextOptions<CalculadoraContext> options) : base(options) { }

        public DbSet<Operacion> Operaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.ToTable("operaciones");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Num1).HasColumnName("num1");
                entity.Property(e => e.Num2).HasColumnName("num2");
                entity.Property(e => e.TipoOperacion).HasColumnName("tipo_operacion");
                entity.Property(e => e.Resultado).HasColumnName("resultado");
                entity.Property(e => e.Fecha).HasColumnName("fecha");
            });
        }
    }
}