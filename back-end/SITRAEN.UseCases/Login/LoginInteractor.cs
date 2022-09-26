
using Microsoft.Extensions.Options;
using NEWSHORE.DTOs.Login;
using NEWSHORE.Entities.Interfaces;
using NEWSHORE.UseCases.token;
using NEWSHORE.UseCasesPorts.Login;
using System.IdentityModel.Tokens.Jwt;


namespace NEWSHORE.UseCases.Login
{
    public class LoginInteractor : ILoginInPutPort
    {

        private readonly ILoginRepository repository;
        private readonly ILoginOutPutPort outputPort;
        private readonly JwtSettings jwtSettings;

        public LoginInteractor(ILoginRepository repository, ILoginOutPutPort outputPort, IOptions<JwtSettings> jwtSettings)
        {
            this.repository = repository;
            this.outputPort = outputPort;
            this.jwtSettings = jwtSettings.Value;
        }

        public Task Handle(LoginDTO login)
        {
            var logindto = this.repository.Login(login);
            logindto.Token = new JwtSecurityTokenHandler().WriteToken(GeneraToken.GeneratorToken(login, this.jwtSettings));

            this.outputPort.Handle(login);
            return Task.CompletedTask;

        }
    }
}
