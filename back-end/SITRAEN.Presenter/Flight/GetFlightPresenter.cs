
using NEWSHORE.DTOs.Journey;
using NEWSHORE.UseCasesPorts.Flight;

namespace NEWSHORE.Presenter.Flight
{
    public class GetFlightPresenter : IGetFlightOutPutPort, IPresenter<JourneyDTO>
    {
        public JourneyDTO Content {get;private set;}

        public Task Handle(JourneyDTO journey)
        {
            Content = journey;
            return Task.CompletedTask;
        }

   
    }
}
