using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Plane
    {
        public virtual ICollection<Flight> flights { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }


   
        public override string? ToString()
        {
            return "\nCapacity : " + Capacity.ToString()+ " ManufactureDate : " + ManufactureDate.ToString() + " PlaneId : " + PlaneId.ToString() + " PlaneType : "+ PlaneType.ToString();
        }
    }
}
