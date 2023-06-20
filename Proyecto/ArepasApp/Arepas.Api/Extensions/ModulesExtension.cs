using Arepas.Api.Dtos;
using Arepas.Api.Mapping;
using Arepas.Api.Validators;
using Arepas.Application.Interfaces;
using Arepas.Application.Services;
using Arepas.Domain.Interfaces.Repositories;
using Arepas.Infrastructure.Repositories;
using AutoMapper;
using FluentValidation;

namespace Arepas.Api.Extensions;

public static class ModulesExtension
{

    public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        
        return services;
    }


    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderDetailService, OrderDetailService>();


        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CustomerDto>, CustomerValidator>();
        services.AddScoped<IValidator<ProductDto>, ProductValidator>();
        services.AddScoped<IValidator<OrderDto>, OrderValidator>();
        services.AddScoped<IValidator<OrderDetailDto>, OrderDetailValidator>();

        return services;
    }

    public static IServiceCollection AddMappinmg(this IServiceCollection services)
    {

        // Auto Mapper Configurations
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        
        return services;
    }
}