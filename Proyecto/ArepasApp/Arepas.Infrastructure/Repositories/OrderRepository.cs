using Arepas.Domain.Interfaces.Repositories;
using Arepas.Domain.Models;
using Arepas.Infrastructure.Common;
using Arepas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Arepas.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly AppDbContext _appDbContext;

    public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Order> GetByOrderIdAsync(int orderId)
    {
        return await _appDbContext.Orders.Where(x => x.Id == orderId).Include("Orderdetails").Include("Orderdetails.Product").FirstAsync();
    }

    public async Task<Order> RemoveAsync(int id)
    {
        return await _appDbContext.Orders.Where(p => p.Id == id).Include("Orderdetails").FirstOrDefaultAsync();
    }
}

    
