using Arepas.Domain.Common;
using Arepas.Domain.Models;

namespace Arepas.Domain.Interfaces.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    public Task<Order> GetByOrderIdAsync(int orderId);
    public Task<Order> RemoveAsync(int id);
}


