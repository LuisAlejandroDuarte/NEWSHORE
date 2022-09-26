using Microsoft.Extensions.DependencyInjection;
using NEWSHORE.Presenter.Flight;
using NEWSHORE.Presenter.Login;
using NEWSHORE.UseCasesPorts.Flight;
using NEWSHORE.UseCasesPorts.Login;

namespace NEWSHORE.Presenter
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            


            //Flight            
            services.AddScoped<IGetFlightOutPutPort, GetFlightPresenter>();
            services.AddScoped<IGetAllFlightOutPutPort, GetAllFlightPresenter>();
            //Login
            services.AddScoped<ILoginOutPutPort, LoginPresenter>();



            return services;
        }
    }
}
