using UsuarioService.Core.Entities;
using UsuarioService.Core.Interfaces;

namespace UsuarioService.Application.Services;

public class UsuarioServices
{
    private readonly IUsuarioRepository _repository;

    public UsuarioServices(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
    public async Task<Usuario?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
    public async Task AddAsync(Usuario usuario)
    {
        await _repository.AddAsync(usuario);
    }
    public async Task UpdateAsync(Usuario usuario)
    {
        await _repository.UpdateAsync(usuario);
    }
    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
