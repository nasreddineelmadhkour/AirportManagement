using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public virtual ICollection<Flight> flights { get; set; }
        [Key]
        public int Id { get; set; }

        [Display(Name = "Date of Birth"),DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [StringLength(7)]
        public String PassportNumber { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public String EmailAddress { get; set; }
        [MinLength(3, ErrorMessage = "FirstName doit etre >3 "),MaxLength(25, ErrorMessage = "FirstName doit etre <25")]
        public String FirstName { get; set; }
        public String LastName { get; set; }

        [RegularExpression(@"[^0-9]{8}$", ErrorMessage = "doit etre numero 8 chiffre")]
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
