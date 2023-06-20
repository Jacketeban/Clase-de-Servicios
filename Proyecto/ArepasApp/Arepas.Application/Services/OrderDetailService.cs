using Arepas.Application.Interfaces;
using Arepas.Domain.Dtos;
using Arepas.Domain.Exceptions;
using Arepas.Domain.Interfaces.Repositories;
using Arepas.Domain.Models;
using System;
using System.Linq.Expressions;

namespace Arepas.Application.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetail> AddAsync(OrderDetail entity)
        {
            var order = await _orderDetailRepository.GetByIdAsync(entity.OrderId);
            var product = await _orderDetailRepository.GetByIdAsync(entity.ProductId);

            if (order == null && product == null)
            {
                throw new NotFoundException($"Product con id=[{entity.ProductId}] no existe y Order con id=[{entity.OrderId}] no existe");
        
            }
            else if (product == null)
            {
                throw new NotFoundException($"El Producto con Id={entity.ProductId} No existe");
            }else if (order == null)
            {
              
                throw new NotFoundException($"La Orden con Id={entity.OrderId} No existe");

            }

            return await _orderDetailRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<OrderDetail>> FindAsync(Expression<Func<OrderDetail, bool>> predicate)
        {
            return await _orderDetailRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await _orderDetailRepository.GetAllAsync();
        }

      

        public async Task<OrderDetail> GetByIdAsync(int id)
        {
            var entity = await _orderDetailRepository.GetByIdAsync(id);

            if (entity is null)
            {
                throw new NotFoundException($"Registro con Id={id} No Encontrado");
            }

            return entity;
        }

        public async Task<ResponseData<OrderDetail>> GetByQueryParamsAsync(QueryParams queryParams)
        {
            return await _orderDetailRepository.GetByQueryParamsAsync(queryParams);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _orderDetailRepository.GetByIdAsync(id);

            if (entity is null)
            {
                throw new NotFoundException($"Registro con Id={id} No Encontrado");
            }

            await _orderDetailRepository.RemoveAsync(entity);
        }

        public async Task<OrderDetail> UpdateAsync(int id, OrderDetail entity)

        {

            var order = await _orderDetailRepository.GetByIdAsync(entity.OrderId);
            var product = await _orderDetailRepository.GetByIdAsync(entity.ProductId);

            if (id != entity.Id)
            {
                throw new BadRequestException($"El Id={id} No Corresponde con el Id={entity.Id} del Registro");

            }else if (order == null && product == null)
            {
                throw new NotFoundException($"El Product con Id=[{entity.ProductId}] No Existe y La Orden con Id=[{entity.OrderId}] No Existe");

            }else if (product == null)
            {
                throw new NotFoundException($"El Producto con Id={entity.ProductId} No existe");

            }else if (order == null)
            {
                throw new NotFoundException($"La Orden con Id={entity.OrderId} No existe");
            }

            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);

            if (orderDetail is null)
            {
                throw new NotFoundException($"Registro con Id={id} No Encontrado");
            }

            await _orderDetailRepository.UpdateAsync(entity);

            return entity;
        }
    }
}