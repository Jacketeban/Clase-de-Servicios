﻿using Microsoft.EntityFrameworkCore;
using TeamsApi.Context;
using TeamsAPI.Models;

namespace TeamsApi.Services
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContext _appDbContext;

        public TeamService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Team> CreateTeam(Team team)
        {
            _appDbContext.Set<Team>().Add(team);
            await _appDbContext.SaveChangesAsync();
            return team;
        }

        public async Task DeleteTeam(int id)
        {
            var original = await _appDbContext.Set<Team>().FindAsync(id);

            if (original is null)
            {
                throw new Exception($"Team with Id={id} Not Found");
            }

            _appDbContext.Set<Team>().Remove(original);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Team>> GetAllTeams()
        {
            return await _appDbContext.Set<Team>().ToListAsync<Team>();
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await _appDbContext.Set<Team>().FindAsync(id);
        }

        public async Task<Team> UpdateTeam(Team team)
        {
            var id = team?.Id;
            var original = await _appDbContext.Set<Team>().FindAsync(id);

            if (original is null)
            {
                throw new Exception($"Team with Id={id} Not Found");
            }

            _appDbContext.Entry(original).CurrentValues.SetValues(team);
            await _appDbContext.SaveChangesAsync();

            return team;
        }
    }
}
