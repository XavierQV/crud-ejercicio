using crud_ejercicio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud_ejercicio.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,UserRole,String>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Persona> Persona { get; set; }
         public virtual DbSet<Genero> Generos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("Genero");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Persona__06370DAD9E233C5F");

                entity.ToTable("Persona");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoGeneroNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.CodigoGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Genero");
            });
        }
    }
}
