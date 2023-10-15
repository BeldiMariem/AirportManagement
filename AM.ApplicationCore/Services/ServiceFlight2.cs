using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight2 : IServiceFlight2
    {
        public Action<Plane> FlightDetailDel;
        public Func<String, double> durationAvregDel;
        public ServiceFlight2()
        {
            // FlightDetailDel = showFlighhtDetails;
            FlightDetailDel = p =>
            {
                var req = from f in Flights
                          where f.Plane == p
                          select new { f.Destination, f.FlightDate };
                foreach (var f in req)
                    Console.WriteLine(f);

            };
            //durationAvregDel = DurationAverage;
            durationAvregDel = d =>
            {
                var req = from flight in Flights
                          where flight.Destination == d
                          select flight.EstimatedDuration;
                return req.Average();
            };

        }


        public List<Flight> Flights { get; set; } = new List<Flight>();

        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> result = new List<DateTime>();
            /*   for (int i = 0; i < Flights.Count; i++)
               {
                   if (Flights[i].Destination == destination)
                       result.Add(Flights[i].FlightDate); }*/
            /*foreach (Flight flight in Flights)
                if (flight.Destination == destination)
                    result.Add(flight.FlightDate);*/
            result = (from flight in Flights
                      where flight.Destination == destination
                      select flight.FlightDate).ToList();
            var result2 = Flights.Where(f => f.Destination == destination)
                 .Select(f => f.FlightDate);
            //return result ; 
            return result2.ToList();


        }


        public void GetFlights(string filterType, string filtervalue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight flight in Flights)
                        if (flight.Destination == filtervalue)
                            Console.WriteLine(flight);
                    break;
                case "Departure":
                    foreach (Flight flight in Flights)
                        if (flight.Departure != filtervalue)
                            Console.WriteLine(flight);
                    break;
                case "EstimatedDuration":
                    foreach (Flight flight in Flights)
                        if (flight.EstimatedDuration == Int32.Parse(filtervalue))
                            Console.WriteLine(flight);
                    break;
                case "FlightDate":
                    foreach (Flight flight in Flights)
                        if (flight.FlightDate == DateTime.Parse(filtervalue))
                            Console.WriteLine(flight);
                    break;

            }
        }

        public void showFlighhtDetails(Plane plane)
        {
            var req = from f in Flights
                      where plane == f.Plane
                      select new { f.Destination, f.FlightDate };
            var req2 = Flights.Where(f => plane == f.Plane)
                 .Select(f => new { f.Destination, f.FlightDate });
            // foreach (var f in req)
            foreach (var f in req2)
                Console.WriteLine(f);
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var req = from f in Flights
                      where ((f.FlightDate - startDate).TotalDays < 8
                      && (f.FlightDate - startDate).TotalDays > 0)
                      select f;
            var req2 = Flights.Where(f => (f.FlightDate - startDate).TotalDays < 8
            && (f.FlightDate - startDate).TotalDays > 0);
            return req.Count();
        }

        public double DurationAverage(string destination)
        {
            var req = from flight in Flights
                      where flight.Destination == destination
                      select flight.EstimatedDuration;
            var req2 = Flights.Where(f => f.Destination == destination)
                .Average(f => f.EstimatedDuration);
            //return req.Average();
            return req2;
        }

        public List<Flight> OrderedDurationFlights()
        {
            var req = from flight in Flights
                      orderby flight.EstimatedDuration descending
                      select flight;
            var req2 = Flights.OrderByDescending(f => f.EstimatedDuration);
            return req.ToList();
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlight()
        {
            var req = from flight in Flights
                      group flight by flight.Destination;
            var req2 = Flights.GroupBy(f => f.Destination);
            foreach (var g in req)
            {
                Console.WriteLine(g.Key);
                foreach (Flight flight in g)
                    Console.WriteLine(flight);
            }
            return req;
        }

  /*      public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            var req = from p in flight.Passengers.OfType<Traveller>()
                      orderby p.BirthDate
                      select p;
            var req2 = flight.Passengers.OfType<Traveller>().OrderBy(t => t.BirthDate);
            return req.Take(3);
            //pour ingnorer 3 Skip(3)
        }*/

        public void ShowFlightDetails(Plane plane)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            throw new NotImplementedException();
        }
    }
}