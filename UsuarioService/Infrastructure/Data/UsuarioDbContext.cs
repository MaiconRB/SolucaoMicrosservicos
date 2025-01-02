using Microsoft.EntityFrameworkCore;
using UsuarioService.Core.Entities;

namespace UsuarioService.Infrastructure.Data
{
    public class UsuarioDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            //modelBuilder.Entity<Usuario>().Property(u => u.Nome).IsRequired().HasMaxLength(100);
            //modelBuilder.Entity<Usuario>().Property(u => u.Email).IsRequired().HasMaxLength(100);
            //modelBuilder.Entity<Usuario>().Property(u => u.Senha).IsRequired().HasMaxLength(100);
        }

    }
}
