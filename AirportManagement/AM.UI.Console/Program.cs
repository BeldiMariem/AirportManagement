// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Infrastrectur;
using System;

Console.WriteLine("Hello, World!");
Plane p = new Plane();
p.Capacity = 100;
//p.ManufactureDate= DateTime.Now; 
p.ManufactureDate = new DateTime(2010, 5, 23);
p.PlaneType = PlaneType.Airbus;

Console.WriteLine(p);

//Plane p2 = new Plane(PlaneType.Airbus, 100, DateTime.Now);
Plane p3 = new Plane()
{
    Capacity = 100,
    ManufactureDate = DateTime.Now,
    PlaneType = PlaneType.Boeing,
};

Console.WriteLine(p3);
//tester la methode CheckProfile

Passenger p1 = new Passenger()
{
    FullName=new FullName { FirstName = "Ahmed" , LastName = "Souissi" },
   
    EmailAdress = "ahmed.souissi@gmail.com"
};
bool b1 = p1.CheckProfile("Ahmed", "Souissi");
bool b2 = p1.CheckProfile("Ahmed", "Souissi", "ahmed.souissi@gmail.comA");
Console.WriteLine("Instruction1 " + b1 + " Instruction2 " + b2);

//tester la methode PassengerType
Traveller t1 = new Traveller()
{
    FullName = new FullName { FirstName = "Aziz" , LastName = "Mabrouk" }
 
};

Staff s1 = new Staff()
{
    FullName = new FullName { FirstName = "Walid", LastName = "Maalej" }
    
};

p1.PassengerType();
t1.PassengerType();
s1.PassengerType();

ServiceFlight2 sf = new ServiceFlight2();
sf.Flights=TestData.listFlights;
Console.WriteLine("***************** partie services ******************");
Console.WriteLine("Get Flight dates");
foreach (var f in sf.GetFlightDates("Paris")) 
Console.WriteLine(f);
Console.WriteLine("GetFlights");
sf.GetFlights("FlightDate", "01/06/2022 20:10:10");
Console.WriteLine("show flight details");
sf.FlightDetailDel(TestData.BoingPlane);
Console.WriteLine("programmed flight number");
Console.WriteLine(sf.ProgrammedFlightNumber(new DateTime(2022, 01, 31)));
Console.WriteLine("duration average");
Console.WriteLine(sf.durationAvregDel("Madrid"));
Console.WriteLine("OrderedDurationFlights");
foreach (Flight f in sf.OrderedDurationFlights()) 
Console.WriteLine(f);
Console.WriteLine("DestinationGroupedFlights");
sf.DestinationGroupedFlight();
Console.WriteLine("SeniorTravellers");
//foreach(Traveller t in sf.SeniorTravellers(TestData.flight1))
//Console.WriteLine(t);

Console.WriteLine("passenger extention");
TestData.traveller1.UpperFullName();
Console.WriteLine(TestData.traveller1);
Console.WriteLine("********************Insertion donees ****************************");
AMContext ctx = new AMContext();
IUnitOfWork uow = new UnitOfWork(ctx);
IServicePlane sp = new ServicePlane(uow);
IserviceFlight sf1 = new ServiceFlight(uow);
//sf1.Add(TestData.flight1);
sp.Add(TestData.Airbusplane);
sp.Commit();
//uow.Save();
// insertion des données
//ctx.Planes.Add(TestData.BoingPlane);
//ctx.Planes.Add(TestData.Airbusplane);

//ctx.Flights.Add(TestData.flight1);
//ctx.Flights.Add(TestData.flight2);
//ctx.Flights.Add(TestData.flight3);

//persistance
//ctx.SaveChanges();
//Console.WriteLine("Isertion avec succés");

// Affichage
Console.WriteLine("les vols dont L'ID est < 5");

    foreach (Flight f in sf1.GetMany(f=>f.FlightId<5))
    Console.WriteLine("Date du vol : " + f.FlightDate + " Flight Capacity : " + f.Plane.Capacity);

Console.WriteLine("les avions de la table plane");
foreach(Plane pl in sp.GetMany())
    Console.WriteLine(pl);

//foreach (Flight f in sp.GetMany(f => f.PlaneId < 5))
//    Console.WriteLine("Destination : " + f.Destination + " Plane Capacity : " + f.Plane.Capacity);










