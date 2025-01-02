using Microsoft.EntityFrameworkCore;
using ProdutoService.Core.Entities;

namespace ProdutoService.Infrastructure.Data
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }

    }
}
