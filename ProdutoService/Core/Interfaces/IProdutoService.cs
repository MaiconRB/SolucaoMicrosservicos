using ProdutoService.Core.Entities;

namespace ProdutoService.Core.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<Produto>> GetAllAsync();
    Task<Produto?> GetByIdAsync(Guid id);
    Task AddAsync(Produto produto);
    Task UpdateAsync(Produto produto);
    Task DeleteAsync(Guid id);
}
