using Arepas.Domain.Interfaces.Repositories;
using Arepas.Domain.Models;
using Arepas.Infrastructure.Common;
using Arepas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Arepas.Infrastructure.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    private readonly AppDbContext _appDbContext;

    public CustomerRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Customer> GetOrdersByCustomerIdAsync(int customerId)
    {
       return await _appDbContext.Customers.Where(x => x.Id == customerId).Include("Orders").FirstOrDefaultAsync();
    }

    public async Task<Customer> LoginAsync(Customer entity)
    {
        return await _appDbContext.Customers.Where(d => d.UserEmail == entity.UserEmail && d.Password == entity.Password).
            FirstOrDefaultAsync();
    }

    public async Task<Customer> GetByEmailAsync(string customerEmail)
    {
        return await _appDbContext.Customers.Where(x => x.UserEmail == customerEmail).FirstOrDefaultAsync();
    }
}