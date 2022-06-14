using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }


       public string Model { get; set; }
       public Engine Engine { get; set; }
       public int Weight { get; set; }
       public string Color { get; set; }

       public override string ToString()
       {
           StringBuilder sb = new StringBuilder();

           sb.AppendLine($"{Model}:");
           sb.AppendLine($"  {Engine.Model}:");
           sb.AppendLine($"    Power: {Engine.Power}");
           sb.AppendLine($"    Displacement: {(Engine.Displacement != 0 ? Engine.Displacement.ToString() : "n/a")}");
           sb.AppendLine($"    Efficiency: {Engine.Efficiency ?? "n/a"}");
           sb.AppendLine($"  Weight: {(Weight != 0 ? Weight.ToString() : "n/a")}");
           sb.AppendLine($"  Color: {Color ?? "n/a"}");

           return sb.ToString().TrimEnd();
       }
    }
}