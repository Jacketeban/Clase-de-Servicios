using Microsoft.EntityFrameworkCore;
using Pricat.Domain.Entities;
using Pricat.Domain.Interfaces.Repositories;
using Pricat.Infrastructure.Common;
using Pricat.Infrastructure.Context;

namespace Pricat.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task RemoveeProductsByCategoryIdAsync(IEnumerable<Product> products)
    {
        _appDbContext.Set<Product>().RemoveRange(products);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        return await _appDbContext.Set<Product>().Where(p => p.CategoryId == categoryId).ToListAsync();

    }

    
}
