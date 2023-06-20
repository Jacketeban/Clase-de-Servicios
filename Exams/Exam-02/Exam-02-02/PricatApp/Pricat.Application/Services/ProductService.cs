using Pricat.Application.Interfaces;
using Pricat.Domain.Entities;
using Pricat.Domain.Exceptions;
using Pricat.Domain.Interfaces.Repositories;
using Pricat.Utilities;
using System.Linq.Expressions;

namespace Pricat.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> AddAsync(Product entity)
    {
        if (!Ean13Calculator.IsValid(entity.EanCode))
        {
            throw new BadRequestException($"EAN Code [{entity.EanCode}] is Not Valid");
        }


        if (!await _productRepository.CategoryExistAsync(entity.CategoryId))
        {
            throw new NotFoundException($"Category [{entity.CategoryId}] Not Found");
        }
        return await _productRepository.AddAsync(entity);
    }

    public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
    {
        return await _productRepository.GetByCategoryIdAsync(categoryId);
    }

    public async Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate)
    {
        return await _productRepository.FindAsync(predicate);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null)
        {
            throw new NotFoundException($"Product [{id}] Not Found");
        }

        return product;
    }

    public async Task RemoveAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null)
        {
            throw new NotFoundException($"Product [{id}] Not Found");
        }

        await _productRepository.RemoveAsync(product);
    }

    public async Task<Product> UpdateAsync(int id, Product entity)
    {
        if (id != entity.Id)
        {
            throw new BadRequestException($"Id [{id}] is different to Product.Id [{entity.Id}]");
        }

             if (!Ean13Calculator.IsValid(entity.EanCode))
        {
            throw new BadRequestException($"EAN Code [{entity.EanCode}] is Not Valid");
        }

        var product = await _productRepository.GetByIdAsync(id);



        if (product is null)
        {
            throw new NotFoundException($"Product [{id}] Not Found");
        }

        if (!await _productRepository.CategoryExistAsync(entity.CategoryId))
        {
            throw new NotFoundException($"Category [{entity.CategoryId}] Not Found");
        }

        return (await _productRepository.UpdateAsync(entity));
    }
}