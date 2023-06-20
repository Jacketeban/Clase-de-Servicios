using Microsoft.Extensions.DependencyInjection;
using School.Application.Interfaces;
using School.Application.Services;
using School.Domain.Common;
using School.Domain.Entities;
using School.Domain.Interfaces.Repositories;
using School.Infrastructure.Common;
using School.Infrastructure.Repositories;

namespace School.Api.Extensions
{
    public static class ModuleCollectionExtension
    {
        public static IServiceCollection AddCoreModules(this IServiceCollection services)
        {
            // Services / Use Cases
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }

        public static IServiceCollection AddInfrastructureModules(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();


            return services;
        }
    }
}