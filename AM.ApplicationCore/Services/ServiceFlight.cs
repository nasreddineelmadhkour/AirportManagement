using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight
    {
        public List<Flight> flights { get; set; }

        /*public List<DateTime> GetFlightDates(string destination)
        {
            List <DateTime> dates = new List<DateTime>();
            
            for (int i = 0; i < flights.Count; i++)
            {
                if(flights[i].Destination == destination)
                {
                    dates.Add(flights[i].FlightDate);
                }

            }
            return dates;
        } */
        
        //par foreach
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();

            foreach (var flight in flights)
            {
                if (flight.Destination== destination)
                {
                    dates.Add(flight.FlightDate);
                }
            }
            return dates;
        }


        public void GetFlights(string filterType,string filterValue)
        {

            for (int i = 0; i < flights.Count; i++)
            {
                switch (filterType)
                { 
                    case "Destination":
                        {

                            if (filterValue == flights[i].Destination)
                                Console.WriteLine(flights[i].ToString());

                        }

                
                    break;

                    case "FlightDate":
                        {

                            if (DateTime.Parse(filterValue) == flights[i].FlightDate)
                                Console.WriteLine(flights[i].ToString());
                           
                        }
                        break ;

                    case "EffectiveArrival":
                        {
                            
                            if (DateTime.Parse(filterValue) == flights[i].EffectiveArrival)
                                Console.WriteLine(flights[i].ToString());
                            

                        }
                        break ;

                    default:
                        Console.WriteLine("\nDefault\n");

                        break;

                }
            }

        }
    }
}
