namespace DefiningClasses
{
    public class Car
    {
       public Car(string model, int speed, int power, int weight, string type, double tire1Pressure, int tire1Age,
           double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)

       {
           Model = model; 
           Engine = new Engine(speed, power);
           Cargo = new Cargo(type, weight);
           Tires = new Tires[]
           {
               new Tires(tire1Pressure, tire1Age),
               new Tires(tire2Pressure, tire2Age),
               new Tires(tire3Pressure, tire3Age),
               new Tires(tire4Pressure, tire4Age)
           };
       }

       public string Model { get; set; }
       public Engine Engine { get; set; }
       public Cargo Cargo { get; set; }
       public Tires[] Tires { get; set; }

    }
}