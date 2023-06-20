using Arepas.Application.Interfaces;
using Arepas.Domain.Dtos;
using Arepas.Domain.Exceptions;
using Arepas.Domain.Interfaces.Repositories;
using Arepas.Domain.Models;
using System;
using System.Linq.Expressions;

namespace Arepas.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
      

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
          
        }

        public async Task<Order> AddAsync(Order entity)
        {
       
       
            return await _orderRepository.AddAsync(entity);
        }


      

        public async Task<IEnumerable<Order>> FindAsync(Expression<Func<Order, bool>> predicate)
        {
            return await _orderRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var entity = await _orderRepository.GetByIdAsync(id);

            if (entity is null)
            {
                throw new NotFoundException($"Registro con Id={id} No Encontrado");
            }

            return entity;
        }

        public async Task<ResponseData<Order>> GetByQueryParamsAsync(QueryParams queryParams)
        {
            return await _orderRepository.GetByQueryParamsAsync(queryParams);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _orderRepository.GetByIdAsync(id);

            if (entity is null)
            {
                throw new NotFoundException($"Registro con Id={id} No Encontrado");
            }

            if (entity.Orderdetails != null && entity.Orderdetails.Count > 0)
            {
                throw new InternalServerErrorException($"No es Posible Eliminar el Registro {id} por Valores Dependientes Asociados");
            }

            await _orderRepository.RemoveAsync(entity);
        }


        public async Task<Order> UpdateAsync(int id, Order entity)

        {

            var order = await _orderRepository.GetByIdAsync(entity.CustomerId);

            if (id != entity.Id)
            {
                throw new BadRequestException($"El Id={id} No Corresponde con el Id={entity.CustomerId} del Registro");

            }

            else if (order == null)
            {
                throw new NotFoundException($"El Producto con Id={entity.CustomerId} No existe");

            }

            await _orderRepository.UpdateAsync(entity);

            return entity;
        }

        public async Task<Order> GetByOrderIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order == null)
            {
                throw new NotFoundException($"Registro con Id={orderId} No Encontrado");
            }

            return await _orderRepository.GetByOrderIdAsync(orderId);
        }




    }
}