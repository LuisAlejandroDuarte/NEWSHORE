using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NEWSHORE.DTOs.Flight;
using NEWSHORE.DTOs.Journey;
using NEWSHORE.Presenter;
using NEWSHORE.UseCasesPorts.Flight;

namespace NEWSHORE.Controllers.Suscriptores
{

    [Route("api/[controller]")]
    [ApiController]
    public class GetFlightController
    {
        readonly IGetFlightInPutPort inPutPort;
        readonly IGetFlightOutPutPort outPutPort;

        public GetFlightController(IGetFlightInPutPort inPutPort, IGetFlightOutPutPort outPutPort)
        {
            this.inPutPort = inPutPort;
            this.outPutPort = outPutPort;
        }

        [HttpPost]
        //[Authorize]
        public async Task<JourneyDTO> GetFlight(FlightDTO flight)
        {
            await this.inPutPort.Handle(flight);
            var datos = ((IPresenter<JourneyDTO>)outPutPort).Content;
            return ((IPresenter<JourneyDTO>)outPutPort).Content;
        }
    }
}
