using NEWSHORE.Entities.Interfaces;
using NEWSHORE.UseCasesPorts.Flight;

namespace NEWSHORE.UseCases.Personaes.GetAll
{
    public class GetAllFlightInteractor : IGetAllFlightInPutPort
    {

        readonly IFlightRepository repository;
        readonly IGetAllFlightOutPutPort outPutPort;

        public GetAllFlightInteractor(IFlightRepository repository, IGetAllFlightOutPutPort outPutPort)
        {
            this.repository = repository;
            this.outPutPort = outPutPort;
        }

        public async Task Handle()
        {
           var vuelos = await this.repository.GetAll();
           await this.outPutPort.Handle(vuelos);                        
        }
    }
}
