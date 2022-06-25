using System;

namespace Drones
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Airfield airfield = new Airfield("Heathrow", 10, 10.5);
            Drone drone = new Drone("D20", "DEERC", 6);


            Console.WriteLine(drone);

            Console.WriteLine(airfield.AddDrone(drone));

            Console.WriteLine(airfield.Count);

            Console.WriteLine(airfield.Report());
        }
    }
}
