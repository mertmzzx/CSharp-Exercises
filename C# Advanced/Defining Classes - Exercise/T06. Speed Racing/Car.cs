using System;

namespace DefiningClasses
{
    public class Car
    {
       //Fields - характеристики на колите
       private string model;
       private double fuelAmount;
       private double fuelConsumptionPerKilometer;
       private double travelledDistance;

       //Constructor - създаване на обект от класа
       public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
       {
           Model = model;
           FuelAmount = fuelAmount;
           FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
           TravelledDistance = 0;
       }

       //Properties
       public string Model { get; set; }
       public double FuelAmount { get; set; }
       public double FuelConsumptionPerKilometer { get; set; }
       public double TravelledDistance { get; set; }

       //Method
       public void Drive(double amountOfKm)
       {
           double neededFuel = amountOfKm * FuelConsumptionPerKilometer;
           if (FuelAmount >= neededFuel)
           {
               FuelAmount -= neededFuel;
               TravelledDistance += amountOfKm;
           }
           else
           {
               Console.WriteLine("Insufficient fuel for the drive");
           }
       }
    }
}