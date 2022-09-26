
using NEWSHORE.DTOs.Flight;
using NEWSHORE.UseCasesPorts.Flight;


namespace NEWSHORE.Presenter.Flight
{
    public class GetAllFlightPresenter : IGetAllFlightOutPutPort, IPresenter<List<FlightDTO>>

    {
        public List<FlightDTO> Content { get; private set; }

        public Task Handle(List<FlightDTO> flights)
        {
            Content = flights;
            return Task.CompletedTask;
        }
    }
}
