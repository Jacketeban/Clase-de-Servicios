using Microsoft.AspNetCore.Mvc;
using School.Application.Interfaces;
using School.Domain.Entities;
using School.Domain.Exceptions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public SchoolController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentService.GetAllAsync());
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _studentService.GetByIdAsync(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<SchoolController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            return Ok(await _studentService.AddAsync(student));
        }

        // PUT api/<SchoolController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student student)
        {
            try
            {
                return Ok(await _studentService.UpdateAsync(id, student));
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentService.RemoveAsync(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}