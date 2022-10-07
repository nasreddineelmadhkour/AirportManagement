using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public virtual ICollection<Flight> flights { get; set; }
        public DateTime BirthDate { get; set; }
        public String PassportNumber { get; set; }
        public String EmailAddress { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int TelNumber { get; set; }




        public bool CheckProfile(String FirstName,String LastName)
        {
            return this.FirstName.Equals(FirstName) && this.LastName.Equals(LastName);
        }
        public bool CheckProfile(String FirstName, String LastName,String EmailAdress)
        {
            return this.FirstName.Equals(FirstName) && this.LastName.Equals(LastName)&& this.EmailAddress.Equals(EmailAdress);
        }
        public override string? ToString()
        {
            return "\nBirthday : "+ BirthDate.ToString()+ " PassportNumber : " + PassportNumber.ToString() + " EmailAdress : " + EmailAddress.ToString()+ " LastName : " + LastName.ToString()+ " TelNumber : " + TelNumber.ToString();
        }
    
    
    
        public virtual void PassengerType()
        {

            Console.WriteLine("im a passanger ");
           
        }
    
    }



}
