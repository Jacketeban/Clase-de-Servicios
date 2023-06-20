using Arepas.Domain.Common;
using Arepas.Domain.Models;

namespace Arepas.Domain.Interfaces.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    public Task<Customer> GetOrdersByCustomerIdAsync(int customerId);
    public Task<Customer> LoginAsync(Customer entity);

    public Task<Customer> GetByEmailAsync(string customerEmail);
}