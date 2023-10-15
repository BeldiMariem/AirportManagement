using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Airbus, Boeing};
    public class Plane
    {
        [Range(0,int.MaxValue)] 
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }

        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        [NotMapped]
        public string Information { get { return PlaneId + " " + ManufactureDate + " " + Capacity; } }

        public virtual ICollection<Flight> Flights  { get; set; }

        public override string ToString()
        {
            return "Capacity: "+Capacity+" Manufacture Date: " + ManufactureDate;
        }
        //public Plane(PlaneType pt, int capacity, DateTime date)
        //{ PlaneType = pt;
        //Capacity = capacity;
        //ManufactureDate = date; }
    }
}
