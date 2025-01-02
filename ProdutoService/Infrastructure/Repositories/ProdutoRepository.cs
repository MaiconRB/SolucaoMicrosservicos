using Microsoft.EntityFrameworkCore;
using ProdutoService.Core.Entities;
using ProdutoService.Core.Interfaces;
using ProdutoService.Infrastructure.Data;

namespace ProdutoService.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ProdutoDbContext _dbContext;

    public ProdutoRepository(ProdutoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Produto>> GetAllAsync()
    {
        return await _dbContext.Produtos.ToListAsync();
    }

    public async Task<Produto?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Produtos.FindAsync(id);
    }

    public async Task AddAsync(Produto produto)
    {
        await _dbContext.Produtos.AddAsync(produto);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Produto produto)
    {
        _dbContext.Produtos.Update(produto);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _dbContext.Produtos.FindAsync(id);
        if (product != null)
        {
            _dbContext.Produtos.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
