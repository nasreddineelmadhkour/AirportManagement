// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");

ServiceFlight sf = new ServiceFlight();
sf.flights = TestData.listFlights;
