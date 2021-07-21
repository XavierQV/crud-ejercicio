using crud_ejercicio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud_ejercicio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Persona> Persona { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Persona>(ent =>
            {
                ent.HasKey(en => en.Codigo);

                ent.Property(en => en.Nombre)
                //.IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                ent.Property(en => en.Apellido)
                //.IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                ent.Property(en => en.Direccion)
                //.IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            });
        }
    }
}
