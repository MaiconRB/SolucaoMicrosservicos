using Microsoft.EntityFrameworkCore;
using UsuarioService.Core.Entities;
using UsuarioService.Core.Interfaces;
using UsuarioService.Infrastructure.Data;

namespace UsuarioService.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _dbContext;

        public UsuarioRepository(UsuarioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<Usuario?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }
        public async Task AddAsync(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var usuario = await GetByIdAsync(id);

            if (usuario == null) return;
            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            
        }
    }
}
