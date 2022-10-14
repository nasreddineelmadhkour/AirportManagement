using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public Action<Plane> FlightDetailsDel;

        public Func<string, double> DurationAverageDel;

        public ServiceFlight()
        {
            FlightDetailsDel = ShowFlightDetails;
            DurationAverageDel = DurationAverage;
        }
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

        public void ShowFlightDetails(Plane p)
        {
            var querry = from f in flights where f.Plane == p select new { f.FlightDate, f.Destination };
            foreach (var flight in querry)
            {
                Console.WriteLine("Date = "+flight.FlightDate+"Destination = "+flight.Destination);
            }
            /*
            var querry2 = flights.Where(f => f.Plane == p).Select(f =>new {f.FlightDate,f.Destination});
            foreach (var flight in querry2)
            {
                Console.WriteLine("Date = " + flight.FlightDate + "Destination = " + flight.Destination);
            }*/
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var querry = from f in flights
                         where DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays <= 7
                         select f;

            var querry2 = flights.Where(f => DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays <= 7);
           



            return querry.Count();
        }

        public double DurationAverage(string destination)
        {
            var querry = (from f in flights
                          where f.Destination == destination
                          select f.EstimatedDuration).Average();


            var querry2= flights.Where(f=>f.Destination == destination).Select(f=>f.EstimatedDuration).Average();



            return querry;
        }

        public List<Flight> OrderedDurationFlights()
        {
            var querry= from f in flights
                        orderby f.EstimatedDuration descending select f;
            var querry2 = flights.OrderByDescending(f => f.EstimatedDuration);

            return querry.ToList();
        }
        public List<Traveller> SeniorTravellers(Flight flight)
        {
            var querry = from t in flight.passengers.OfType<Traveller>()
                         orderby t.BirthDate
                         select t;

            var querry2= flight.passengers.OfType<Traveller>().OrderBy(f => f.BirthDate);

            return querry.Take(3).ToList();
        }


        public void DestinationGroupedFlights()
        {
            var querry = from f in flights
                         group f by f.Destination;
            var querry2 = flights.GroupBy(f => f.Destination);

            foreach (var groupe in querry)
            {
                Console.WriteLine("Destination = "+groupe.Key);
                foreach (var f in groupe)
                {
                    Console.WriteLine("Décollage : "+f.FlightDate);
                }
            }
        
        }

    }
}
