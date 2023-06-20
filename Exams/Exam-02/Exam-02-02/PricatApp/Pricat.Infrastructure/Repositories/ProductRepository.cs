using Microsoft.EntityFrameworkCore;
using Pricat.Domain.Entities;
using Pricat.Domain.Interfaces.Repositories;
using Pricat.Infrastructure.Common;
using Pricat.Infrastructure.Context;

namespace Pricat.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {

    }

    public async Task<bool> CategoryExistAsync(int categoryId)
    {
        return await _appDbContext.Set<Category>().AnyAsync(c => c.Id == categoryId);
    }

    public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
    {
        return await _appDbContext.Set<Product>().Where(p => p.CategoryId == categoryId).ToListAsync();

    }
}
