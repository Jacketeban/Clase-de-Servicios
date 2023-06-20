using Pricat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pricat.Application.Interfaces;

public interface IProductService
{
    public Task<Product> AddAsync(Product entity);

    public Task<IEnumerable<Product>> GetAllAsync();

    public Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);


    public Task<Product> GetByIdAsync(int id);

    public Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate);

    public Task<Product> UpdateAsync(int id, Product entity);

    public Task RemoveAsync(int id);
}
