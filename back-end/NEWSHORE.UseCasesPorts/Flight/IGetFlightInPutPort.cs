

using NEWSHORE.DTOs.Flight;

namespace NEWSHORE.UseCasesPorts.Flight
{
    public interface IGetFlightInPutPort
    {
        Task Handle(FlightDTO flight);
    }
}
