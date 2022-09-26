using NEWSHORE.DTOs.Login;
using NEWSHORE.Entities.Interfaces;

namespace NEWSHORE.RepositoryEF.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public LoginDTO Login(LoginDTO login)
        {
             if (login.Password=="admin" && login.UserName=="admin")
            {
                return login;
            }
             else
            {
                throw new Exception($"El usuario {login.UserName} no existe");
            }
        }
    }
}
