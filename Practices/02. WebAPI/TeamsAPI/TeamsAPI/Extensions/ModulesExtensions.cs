using TeamsApi.Services;

namespace TeamsAPI.Extensions
{
    public static class ModulesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ITeamService, TeamService>();
        }

        public static 
    }
}
