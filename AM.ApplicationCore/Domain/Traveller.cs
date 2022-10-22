using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public String Nationality { get; set; }
        public String HealthInformation { get; set; }


  

     
  
        public override void PassengerType(){
            base.PassengerType();
            Console.WriteLine( "im Traverller ");
        }
        public override string? ToString()
        {
            return "\nNationality : " + Nationality.ToString() + " HealthInformation : "+ HealthInformation.ToString();
        }
    }
}
