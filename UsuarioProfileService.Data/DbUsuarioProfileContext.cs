using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UsuarioProfileService.Entities;

namespace UsuarioProfileService.Data
{
    public class DbUsuarioProfileContext : DbContext
    {
        public DbSet<UsuarioProfile> UsuarioProfile { get; set; }
        
        public DbUsuarioProfileContext(DbContextOptions<DbUsuarioProfileContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioProfileMap());
        }

    }
}