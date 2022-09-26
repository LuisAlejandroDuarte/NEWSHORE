using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NEWSHORE.Controllers;
using NEWSHORE.Presenter;
using NEWSHORE.RepositoryEF;
using NEWSHORE.UseCases;

namespace NEWSHORE.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddNewShoreDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddUseCasesServices(configuration);
            services.AddPresenters();
            services.AddHttpContext();

            return services;
        }
    }
}
