using NEWSHORE.DTOs.Login;


namespace NEWSHORE.UseCasesPorts.Login
{
    public interface ILoginInPutPort
    {
        Task Handle(LoginDTO login);

    }
}
