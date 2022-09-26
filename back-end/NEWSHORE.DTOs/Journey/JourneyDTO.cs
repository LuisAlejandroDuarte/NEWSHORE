
using NEWSHORE.DTOs.Flight;

namespace NEWSHORE.DTOs.Journey
{
    public class JourneyDTO
    {
        public List<FlightDTO>? Flights { get; set; }
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
