
using Microsoft.AspNetCore.Mvc;
using NEWSHORE.DTOs.Flight;
using NEWSHORE.Presenter;
using NEWSHORE.UseCasesPorts.Flight;

namespace NEWSHORE.Controllers.Flight
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllFlightController
    {

        readonly IGetAllFlightInPutPort inPutPort;
        readonly IGetAllFlightOutPutPort outPutPort;

        public GetAllFlightController(IGetAllFlightInPutPort inPutPort, IGetAllFlightOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpGet]
        //[Authorize]
        public async Task<List<FlightDTO>> GetAllFlight()
        {            

            await inPutPort.Handle();            
            return   ((IPresenter<List<FlightDTO>>)outPutPort).Content;
        }
    }
}
