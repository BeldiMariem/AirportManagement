using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff:Passenger
    {
        public DateTime EmploymentDate { get; set; }

        public string Function { get; set; }

        [DataType(DataType.Currency)]   
        public double Salary { get; set; }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.Write(",I am a Staff member");

        }

    }
}
