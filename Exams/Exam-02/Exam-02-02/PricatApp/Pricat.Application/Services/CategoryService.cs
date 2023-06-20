using Pricat.Application.Interfaces;
using Pricat.Domain.Entities;
using Pricat.Domain.Exceptions;
using Pricat.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace Pricat.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> AddAsync(Category? entity)
    {
        if (entity is null || string.IsNullOrEmpty(entity.Description))
        {
            throw new BadRequestException("Description is Required");
        }
        return await _categoryRepository.AddAsync(entity);
    }

    public async Task<IEnumerable<Category>> FindAsync(Expression<Func<Category, bool>> predicate)
    {
        return await _categoryRepository.FindAsync(predicate);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category is null)
        {
            throw new NotFoundException($"Category [{id}] Not Found");
        }

        return category;
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category is null)
        {
            throw new NotFoundException($"Category [{categoryId}] Not Found");
        }
        return await _categoryRepository.GetProductsByCategoryIdAsync(categoryId);
    }

    public async Task RemoveAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category is null)
        {
            throw new NotFoundException($"Category [{id}] Not Found");
        }

        var products = await _categoryRepository.GetProductsByCategoryIdAsync(id);
  
        if (products.Any())
        {
            await _categoryRepository.RemoveeProductsByCategoryIdAsync(products);
        }

        await _categoryRepository.RemoveAsync(category);
    }

    public async Task<Category> UpdateAsync(int id, Category entity)
    {
        if (id != entity.Id)
        {
            throw new BadRequestException($"Id [{id}] is different to Category.Id [{entity.Id}]");
        }

        var category = await _categoryRepository.GetByIdAsync(id);

        if (category is null)
        {
            throw new NotFoundException($"Category [{id}] Not Found");
        }

        return (await _categoryRepository.UpdateAsync(entity));
    }
}
