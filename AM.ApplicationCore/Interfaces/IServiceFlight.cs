using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        public void ShowFlightDetails(Plane p);
        public void GetFlights(string filterType, string filterValue);

        public List<Flight> OrderedDurationFlights();
        public List<Traveller> SeniorTravellers(Flight flight);
        public void DestinationGroupedFlights();




    }
}
