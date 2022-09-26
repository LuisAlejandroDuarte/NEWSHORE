using Microsoft.AspNetCore.Mvc;
using NEWSHORE.DTOs.Login;
using NEWSHORE.Presenter;
using NEWSHORE.UseCasesPorts.Login;


namespace NEWSHORE.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController
    {

        readonly ILoginInPutPort inPutPort;
        readonly ILoginOutPutPort outPutPort;

        public LoginController(ILoginInPutPort inPutPort, ILoginOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpPost]
        public async Task<LoginDTO> Login(LoginDTO login)
        {

            await inPutPort.Handle(login);
            return ((IPresenter<LoginDTO>)outPutPort).Content;
        }
    }
}
