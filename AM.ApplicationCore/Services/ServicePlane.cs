using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane :Service<Plane>, IServicePlane
    {
     
        public ServicePlane(IUnitOfWork uow):base(uow)
        {
           
        }

        public void DeletePlanes()
        {
            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays > 3650);
        }

        public IEnumerable<Flight> GetFlights(int n)
        {
            return GetMany().OrderByDescending(p=>p.PlaneId).Take(n).SelectMany(p=>p.Flights).OrderBy(f=>f.FlightDate)    ;
        }

        public IEnumerable<Passenger> GetPassenger(Plane p)
        {
          return  p.Flights.SelectMany(f => f.Tickets).Select(t => t.Passenger);
        }

        public bool IsAvailablePlane(int n , Flight f)
        {
            return f.Plane.Capacity >=f.Tickets.Count +  n     ;
        }
    }
}
