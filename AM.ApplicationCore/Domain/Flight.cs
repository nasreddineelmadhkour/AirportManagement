using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public String Airline { get; set; }
        public virtual ICollection<Passenger> passengers { get; set; }

        public int PlaneId { get; set; }
        [ForeignKey("PlaneId")]
        public virtual Plane Plane { get; set; }
        public String Destination { get; set; }
        public String Departure { get; set; }
        public DateTime FlightDate { get; set; }

        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }

      

        public override string? ToString()
        {
            return "FlightDate : " + FlightDate.ToString()+" Destination : "+Destination.ToString()+ " EstimatedDuration : " + EstimatedDuration.ToString()+ " EffectiveArrival:" + EffectiveArrival.ToString();
        }
    }
}
