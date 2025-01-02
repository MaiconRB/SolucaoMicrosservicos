using ProdutoService.Core.Entities;
using ProdutoService.Core.Interfaces;

namespace ProdutoService.Application.Services;

public class ProdutoServices : IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoServices(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Produto>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Produto?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Produto produto)
    {
        await _repository.AddAsync(produto);
    }

    public async Task UpdateAsync(Produto produto)
    {
        await _repository.UpdateAsync(produto);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
