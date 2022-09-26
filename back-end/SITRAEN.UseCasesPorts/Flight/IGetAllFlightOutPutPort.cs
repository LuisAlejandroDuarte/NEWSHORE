
using NEWSHORE.DTOs.Flight;

namespace NEWSHORE.UseCasesPorts.Flight
{
    public interface IGetAllFlightOutPutPort
    {
        Task  Handle(List<FlightDTO> flights);
    }
}
