using NEWSHORE.DTOs.Login;


namespace NEWSHORE.Entities.Interfaces
{
    public interface ILoginRepository
    {
        LoginDTO Login(LoginDTO login);
    }
}
