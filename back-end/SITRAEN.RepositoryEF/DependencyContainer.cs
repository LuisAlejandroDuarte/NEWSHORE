using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NEWSHORE.Entities.Interfaces;
using NEWSHORE.RepositoryEF.Repositories;



namespace NEWSHORE.RepositoryEF
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<HttpClient>();

            return services;

        }
    }
}
