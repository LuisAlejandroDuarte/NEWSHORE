
using NEWSHORE.DTOs.Journey;

namespace NEWSHORE.UseCasesPorts.Flight
{
    public interface IGetFlightOutPutPort
    {
        Task Handle(JourneyDTO journey);
        
    }
}
