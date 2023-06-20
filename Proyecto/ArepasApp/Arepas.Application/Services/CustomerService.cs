using Arepas.Application.Interfaces;
using Arepas.Domain.Dtos;
using Arepas.Domain.Exceptions;
using Arepas.Domain.Interfaces.Repositories;
using Arepas.Domain.Models;
using System;
using System.Linq.Expressions;

namespace Arepas.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
      
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            var existingCustomerEmail = await _customerRepository.GetByEmailAsync(entity.UserEmail);

            if (existingCustomerEmail != null)
            {
                throw new InternalServerErrorException($"El UserEmail '{entity.UserEmail}' Ya Existe");
            }
            return await _customerRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Customer>> FindAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _customerRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }


        public async Task<Customer> GetByIdAsync(int id)
        {
            var entity = await _customerRepository.GetByIdAsync(id);

            if (entity is null)
            {
                throw new NotFoundException($"Registro con Id={id} No Encontrado");
            }

            return entity;
        }

        public async Task<ResponseData<Customer>> GetByQueryParamsAsync(QueryParams queryParams)
        {
            return await _customerRepository.GetByQueryParamsAsync(queryParams);
        }

        public async Task <Customer> GetOrdersByCustomerIdAsync(int customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);

            if (customer is null)
            {
                throw new NotFoundException($"Registro con Id={customerId} No Encontrado");
            }

           return  await _customerRepository.GetOrdersByCustomerIdAsync(customerId);
           
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _customerRepository.GetByIdAsync(id);
            var customer = await GetOrdersByCustomerIdAsync(id);

            if (entity is null)
            {
                throw new NotFoundException($"Registro con Id={id} No Encontrado");
            }

            if (customer.Orders != null && customer.Orders.Count > 0)
            {
                throw new InternalServerErrorException($"No es Posible Eliminar el Registro {id} por Valores Dependientes Asociados");
            }

            await _customerRepository.RemoveAsync(entity);
        }

        public async Task<Customer> UpdateAsync(int id, Customer entity)
        {
            if (id != entity.Id)
            {
                throw new BadRequestException($"El Id={id} No Corresponde con el Id={entity.Id} del Registro");
            }

            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer is null)
            {
                throw new NotFoundException($"Registro con Id={id} No Encontrado");
            }

            await _customerRepository.UpdateAsync(entity);

            return entity;
        }

        //******* LOGIN *******
        public async Task<Customer> LoginAsync(Customer entity)
        {
            var entityDb = await _customerRepository.LoginAsync(entity);

            if (entityDb is null)
            {
                throw new InternalServerErrorException("El UserEmail o la Contraseña son Invalidos");
            }

            return entityDb;
        }
    }
}