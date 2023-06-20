using Pricat.Domain.Common;
using Pricat.Domain.Entities;

namespace Pricat.Domain.Interfaces.Repositories;

public interface ICategoryRepository: IRepository<Category>
{
    public Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    public Task RemoveeProductsByCategoryIdAsync(IEnumerable<Product> products);
}
