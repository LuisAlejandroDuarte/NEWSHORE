

using NEWSHORE.DTOs.Login;
using NEWSHORE.UseCasesPorts.Login;

namespace NEWSHORE.Presenter.Login
{
    public class LoginPresenter : ILoginOutPutPort, IPresenter<LoginDTO>
    {
        public LoginDTO Content {get;private set;}

        public Task Handle(LoginDTO login)
        {
            this.Content=login;
            return Task.CompletedTask;
        }
    }
}
