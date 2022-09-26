using NEWSHORE.DTOs.Login;

namespace NEWSHORE.UseCasesPorts.Login
{
    public interface ILoginOutPutPort
    {
        Task Handle(LoginDTO login);
    }
}
