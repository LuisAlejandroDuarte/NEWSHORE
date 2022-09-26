
using NEWSHORE.DTOs.Transport;

namespace NEWSHORE.DTOs.Flight
{
    public class FlightDTO
    {
        public TransportDTO? Transport { get; set; }
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
