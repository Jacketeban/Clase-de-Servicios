using Microsoft.AspNetCore.Mvc;
using Pricat.Application.Interfaces;
using Pricat.Application.Services;
using Pricat.Domain.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pricat.Api.Controllers;

[Route("api/v1.0/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET: api/<CategoriesController>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _categoryService.GetAllAsync());
    }

    // GET api/<CategoriesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _categoryService.GetByIdAsync(id));
    }

    // GET api/<CategoriesController>/5/Products
    [HttpGet("{categoryId}/Products")]
    public async Task<IActionResult> GetProductsByCategoryIdAsync(int categoryId)
    {
        return Ok(await _categoryService.GetProductsByCategoryIdAsync(categoryId));
    }

    // POST api/<CategoriesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Category? category)
    {
        return Ok(await _categoryService.AddAsync(category));
    }

    // PUT api/<CategoriesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Category category)
    {
        return Ok(await _categoryService.UpdateAsync(id, category));
    }

    // DELETE api/<CategoriesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoryService.RemoveAsync(id);
        return Ok();
    }
}
