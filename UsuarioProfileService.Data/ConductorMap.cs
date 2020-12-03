using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using UsuarioProfileService.Entities;

namespace UsuarioProfileService.Data
{
    public class UsuarioProfileMap : IEntityTypeConfiguration<UsuarioProfile>
    {
        public void Configure(EntityTypeBuilder<UsuarioProfile> builder)
        {
            // ID
            builder.ToTable("Usuario")
                .HasKey(c => c.UsuarioId);
            // NOMBRE
            builder.Property(c => c.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(20)
                .IsUnicode(false);
            // APELLIDO
            builder.Property(c => c.Apellido)
                .HasColumnName("Apellido")
                .HasMaxLength(20)
                .IsUnicode(false);
            // CELULAR
            builder.Property(c => c.Celular)
                .HasColumnName("Celular")
                .HasMaxLength(10)
                .IsUnicode(false);
            // CORREO
            builder.Property(c => c.Correo)
                .HasColumnName("Correo")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
