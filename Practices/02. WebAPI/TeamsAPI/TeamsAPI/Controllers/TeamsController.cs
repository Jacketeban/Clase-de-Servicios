﻿using Microsoft.AspNetCore.Mvc;
using TeamsApi.Services;
using TeamsAPI.Dtos;
using TeamsAPI.Models;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;
        public TeamsController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;  
        }

        // GET: api/<TeamsController>
        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamService.GetAllTeams();
            return Ok(_mapper.Map<List<Team>, List<TeamDto>>(teams));
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamById(id);
            return Ok(_mapper.Map<Team, TeamDto>(team));
        }

        // POST api/<TeamsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TeamDto team)
        {
            return Ok(await _teamService.CreateTeam(_mapper.Map<TeamDto, Team>(team) ));
        }

        // PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TeamDto team)
        {
            return Ok(await _teamService.UpdateTeam(_mapper.Map<TeamDto, Team>(team)));
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamService.DeleteTeam(id);
            return Ok();
        }
    }
}