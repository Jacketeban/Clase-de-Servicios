using Arepas.Api.Dtos;
using Arepas.Application.Interfaces;
using Arepas.Application.Services;
using Arepas.Domain.Dtos;
using Arepas.Domain.Models;
using Arepas.Infrastructure.Context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arepas.Api.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;

        public OrdersController(IMapper mapper, IOrderService orderService, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _orderService = orderService;
            _appDbContext = appDbContext;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryParams queryParams)
        {
            if (queryParams.Page == 0 && queryParams.Limit == 0)
            {
                return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(await _orderService.GetAllAsync()));
            }

            var responseData = await _orderService.GetByQueryParamsAsync(queryParams);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(responseData.XPagination));

            return Ok(_mapper.Map<IEnumerable<OrderDto>>(responseData.Items));
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<OrderDto>(await _orderService.GetByIdAsync(id)));
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDto orderDto)
        {
            return Ok(_mapper.Map<OrderDto>(await _orderService.AddAsync(_mapper.Map<Order>(orderDto))));
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderDto orderDto)
        {
            return Ok(_mapper.Map<OrderDto>(await _orderService.UpdateAsync(id, _mapper.Map<Order>(orderDto))));
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.RemoveAsync(id);
            return Ok();
        }


        // GET: api/v1.0/order/{orderId}/OrderDetails
        [HttpGet("{orderId}/OrderDetails")]

        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            return Ok( _mapper.Map<OrderOrderDetailDto>(await _orderService.GetByOrderIdAsync(orderId)));
      
        }
    }
}