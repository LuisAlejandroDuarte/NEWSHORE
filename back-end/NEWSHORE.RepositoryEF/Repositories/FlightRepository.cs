

using NEWSHORE.DTOs.data;
using NEWSHORE.DTOs.Flight;
using NEWSHORE.DTOs.Journey;
using NEWSHORE.DTOs.Transport;
using NEWSHORE.Entities.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace NEWSHORE.RepositoryEF.Repositories
{
    public class FlightRepository : IFlightRepository
    {
    
        readonly HttpClient client = new HttpClient();

        public FlightRepository(HttpClient client)
        {
            this.client = new HttpClient();
            this.client.BaseAddress = null;
            this.client.BaseAddress = new Uri("https://recruiting-api.newshore.es");
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

       async Task<JourneyDTO> IFlightRepository.Get(FlightDTO flight)
        {
            List<FlightDTO> dataFlight = new List<FlightDTO>();

            JourneyDTO journey = new JourneyDTO();

            HttpResponseMessage vuelos = await this.client.GetAsync("https://recruiting-api.newshore.es/api/flights/1");
            if (vuelos.IsSuccessStatusCode)
            {
                var json =await  vuelos.Content.ReadAsStringAsync();
                List<DataDTO> data =JsonConvert.DeserializeObject<List<DataDTO>>(json);

                foreach (var item in data)
                {
                    dataFlight.Add(new FlightDTO()
                    {
                        Transport = new TransportDTO()
                        {
                            FlightCarrier = item.FlightCarrier,
                            FlightNumber = item.FlightNumber
                        },
                        Origin = item.ArrivalStation,
                        Destination = item.DepartureStation,
                        Price = item.Price
                    });
                }
            }

            List<FlightDTO> encontrados = dataFlight.FindAll(x => x.Origin == flight.Origin || x.Destination == flight.Destination);

            journey.Flights = new List<FlightDTO>();
            journey.Flights.AddRange(encontrados);

            journey.Origin = flight.Origin;
            journey.Destination= flight.Destination;
            
            return journey;
        }

        async Task<List<FlightDTO>> IFlightRepository.GetAll()
        {

            List<FlightDTO> journey = new List<FlightDTO>();
            HttpResponseMessage vuelos = await this.client.GetAsync("https://recruiting-api.newshore.es/api/flights/2");
            if (vuelos.IsSuccessStatusCode)
            {
                var json = await vuelos.Content.ReadAsStringAsync();

                List<DataDTO> data = JsonConvert.DeserializeObject<List<DataDTO>>(json);

                foreach(var item in data)
                {
                    journey.Add(new FlightDTO()
                    {
                        Transport =new DTOs.Transport.TransportDTO()
                        {
                             FlightCarrier =item.FlightCarrier,
                             FlightNumber   =   item.FlightNumber
                        },
                        Origin =item.ArrivalStation,
                        Destination = item.DepartureStation,
                        Price   =item.Price
                    });
                }

            }
     
            return journey;
        }
    }
}
