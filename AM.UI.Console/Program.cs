// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

//Console.WriteLine("Hello, World!");
/*
ServiceFlight sf = new ServiceFlight();

List<DateTime> dates = new List<DateTime>();

dates = sf.GetFlightDates("Madrid");

//par for
/*
for (int i = 0; i < dates.Count; i++)
{
    Console.WriteLine(dates[i].ToString());
}
//par foreach

foreach (DateTime date in dates)
{
    Console.WriteLine(date.ToString());
}

Console.WriteLine("\n par Destination \n");
sf.GetFlights("Destination", "Paris");


Console.WriteLine("\n par FlightDate \n");
sf.GetFlights("FlightDate", "2022/02/01 21:10:10");

Console.WriteLine("\n par EffectiveArrival \n");
sf.GetFlights("EffectiveArrival", "01/01/2022 17:10:10");

*/

ServiceFlight sf=new ServiceFlight();

sf.flights = TestData.listFlights;

//sf.FlightDetailsDel(TestData.BoingPlane);

Passenger p1=new Passenger { FirstName="nasreddine",LastName="madhkour"};
p1.UpperFullName();
Console.WriteLine(p1.FirstName+" "+  p1.LastName);