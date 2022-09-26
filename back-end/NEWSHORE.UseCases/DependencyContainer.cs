
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NEWSHORE.UseCases.Flight.Get;
using NEWSHORE.UseCases.Login;
using NEWSHORE.UseCases.Personaes.GetAll;
using NEWSHORE.UseCases.token;
using NEWSHORE.UseCasesPorts.Flight;
using NEWSHORE.UseCasesPorts.Login;
using System.Text;

namespace NEWSHORE.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            //Flight                                          
            services.AddTransient<IGetFlightInPutPort, GetFlightInteractor>();
            services.AddTransient<IGetAllFlightInPutPort, GetAllFlightInteractor>();
            services.AddTransient<ILoginInPutPort, LoginInteractor>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });
            return services;
        }
    }
}
