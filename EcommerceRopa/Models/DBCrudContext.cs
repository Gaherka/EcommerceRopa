using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EcommerceRopa.Models
{
    public partial class DBCrudContext : DbContext
    {
        public DBCrudContext()
        {
        }

        public DBCrudContext(DbContextOptions<DBCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;
        public virtual DbSet<Prenda> Prenda { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.ToTable("Inventario");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Departamento).HasMaxLength(50);

                entity.Property(e => e.PrendaId).HasColumnName("PrendaID");

                entity.HasOne(d => d.Prenda)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.PrendaId)
                    .HasConstraintName("FK__Inventari__Prend__398D8EEE");
            });

            modelBuilder.Entity<Prenda>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Estilo).HasMaxLength(20);

                entity.Property(e => e.Marca).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Talla).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
