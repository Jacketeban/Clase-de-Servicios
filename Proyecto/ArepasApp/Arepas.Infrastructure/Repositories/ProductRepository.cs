using Arepas.Domain.Interfaces.Repositories;
using Arepas.Domain.Models;
using Arepas.Infrastructure.Common;
using Arepas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Arepas.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly AppDbContext _appDbContext;
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Product> RemoveAsync(int id)
    {
        return await _appDbContext.Products.Where(p => p.Id == id).Include("Orderdetails").FirstOrDefaultAsync();
    }

}