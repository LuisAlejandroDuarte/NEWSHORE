using NEWSHORE.DTOs.Flight;
using NEWSHORE.Entities.Interfaces;
using NEWSHORE.UseCasesPorts.Flight;

namespace NEWSHORE.UseCases.Flight.Get
{
    public class GetFlightInteractor : IGetFlightInPutPort
    {

        readonly IFlightRepository repository;
        readonly IGetFlightOutPutPort outPutPort;

        public GetFlightInteractor(IFlightRepository repository, IGetFlightOutPutPort outPutPort)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
        }

        public async Task Handle(FlightDTO flight)
        {
            var vuelos = await this.repository.Get(flight);
            await this.outPutPort.Handle(vuelos);
        }
    }
}
