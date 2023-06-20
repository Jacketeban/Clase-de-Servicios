using AutoMapper;
using TeamsAPI.Dtos;
using TeamsAPI.Models;

namespace TeamsAPI.Mapping
{

    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<TeamDto, Team>();
            CreateMap<TeamMemberDto, TeamMember>();

        }

    }
}
