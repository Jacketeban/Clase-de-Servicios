using Arepas.Api.Dtos;
using Arepas.Domain.Models;
using AutoMapper;

namespace Arepas.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, Customer>();

            CreateMap<Customer, CustomerDto>()
                 .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<Customer, CustomerOrderDto>()
            .ForMember(dest => dest.Customer, act => act.MapFrom(src => src))
            .ForMember(dest => dest.Orders, act => act.MapFrom(src => src.Orders));

            CreateMap<LoginDto, Customer>();

            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();
 

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetail>();


            CreateMap<OrderDetail, OrderDetailProductDto>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Image, act => act.MapFrom(src => src.Product.Image))
                .ForMember(dest => dest.Price, act => act.MapFrom(src => src.Product.Price));


            CreateMap<Order, OrderOrderDetailDto>()
                .ForMember(dest => dest.Order, act => act.MapFrom(src => src))
                .ForMember(dest => dest.DetailProducts, act => act.MapFrom(src => src.Orderdetails));
        }
    }
}
