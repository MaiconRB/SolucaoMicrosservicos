using Microsoft.EntityFrameworkCore;
using UsuarioService.Core.Entities;

namespace UsuarioService.Infrastructure.Data
{
    public class UsuarioDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options) { }

    }
}
