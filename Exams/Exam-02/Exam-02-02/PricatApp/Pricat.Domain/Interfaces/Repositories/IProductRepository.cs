using Pricat.Domain.Common;
using Pricat.Domain.Entities;

namespace Pricat.Domain.Interfaces.Repositories;

public interface IProductRepository: IRepository<Product>
{
    public Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
    public Task<bool> CategoryExistAsync(int categoryId);
}
