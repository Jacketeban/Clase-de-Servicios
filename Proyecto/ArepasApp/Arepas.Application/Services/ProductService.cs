using Arepas.Application.Interfaces;
using Arepas.Domain.Dtos;
using Arepas.Domain.Exceptions;
using Arepas.Domain.Interfaces.Repositories;
using Arepas.Domain.Models;
using System;
using System.Linq.Expressions;

namespace Arepas.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
      

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
  
        }

        public async Task<Product> AddAsync(Product entity)
        {
            return await _productRepository.AddAsync(entity);
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
            var entity = await _productRepository.GetByIdAsync(id);

            if (entity is null)
            {
                throw new NotFoundException($"Registro con Id={id} No Encontrado");
            }

            return entity;
        }

        public async Task<ResponseData<Product>> GetByQueryParamsAsync(QueryParams queryParams)
        {
            return await _productRepository.GetByQueryParamsAsync(queryParams);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _productRepository.RemoveAsync(id);

            if (entity is null)
            {
                throw new NotFoundException($"Registro con Id={id} No Encontrado");
            }

            if (entity.Orderdetails != null && entity.Orderdetails.Count > 0)
            {
                throw new InternalServerErrorException($"No es Posible Eliminar el Registro {id} por Valores Dependientes Asociados");
            }

            await _productRepository.RemoveAsync(entity);
        }


        public async Task<Product> UpdateAsync(int id, Product entity)
        {
            if (id != entity.Id)
            {
                throw new BadRequestException($"El Id={id} No Corresponde con el Id={entity.Id} del Registro");
            }

            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
            {
                throw new NotFoundException($"Registro con Id={id} No Encontrado");
            }

            await _productRepository.UpdateAsync(entity);

            return entity;
        }

   
    }


}