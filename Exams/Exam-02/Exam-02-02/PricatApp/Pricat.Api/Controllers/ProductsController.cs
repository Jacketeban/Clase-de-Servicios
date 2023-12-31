﻿using Microsoft.AspNetCore.Mvc;
using Pricat.Application.Interfaces;
using Pricat.Domain.Entities;


namespace Pricat.Api.Controllers;

[Route("api/v1.0/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/<ProductController>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _productService.GetAllAsync());
    }

    // GET api/<ProductController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _productService.GetByIdAsync(id));
    }

    // POST api/<ProductController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product? product)
    {
        return Ok(await _productService.AddAsync(product));
    }

    // PUT api/<ProductController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Product product)
    {
        return Ok(await _productService.UpdateAsync(id, product));
    }

    // DELETE api/<ProductController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.RemoveAsync(id);
        return Ok();
    }
}
