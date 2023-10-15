using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public  class Passenger
    {
       // public int Id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Date of birth")]
        public DateTime BirthDate { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }

        public FullName FullName { get; set; }
       
        [RegularExpression("@[0-9]{8}")]
        public string TelNumber { get; set; }

       // public ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return "Birth Date : " + BirthDate + "First Name : " + FullName.FirstName + "Last Name : " + FullName.LastName;

        }

        //public bool CheckProfile(string FirstName, string LastName)

        //{
           
        //        return this.FirstName == FirstName && this.LastName == LastName;
           
        //}

        //public bool CheckProfile(string FirstName, string LastName, string EmailAdress)

        //{

        //    return this.FirstName == FirstName && this.LastName == LastName && this.EmailAdress==EmailAdress;

        //}

        public bool CheckProfile(string FirstName, string LastName, string EmailAdress=null)

        {
            if (EmailAdress != null)

                return this.FullName.FirstName == FirstName && this.FullName.LastName == LastName && this.EmailAdress == EmailAdress;
            else
                return this.FullName.FirstName == FirstName && this.FullName.LastName == LastName;
        }

        public virtual void PassengerType()
        {
            Console.Write("I am a passenger");
        }
    }
}
