namespace VehiclesExtension.Models
{
    using System;
    using Models.Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuentity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuentity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }


        //Full properties => Open to extension
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                this.fuelConsumption = value + this.FuelConsumptionModifier;
            }
        }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            protected set
            {
                if (value < this.FuelQuantity)
                {
                    this.tankCapacity = 0.0;
                }
                else
                {
                    this.tankCapacity = value;
                }
            }
        }

        protected virtual double FuelConsumptionModifier { get; }

        public string Drive(double distance)
        {
            double fuelNeeded;

            if (this.GetType().Name == "Bus")
            {
                fuelNeeded = distance * (this.FuelConsumption + 1.4);
            }
            else
            {
                fuelNeeded = distance * this.FuelConsumption;
            }

            if (fuelNeeded > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public string DriveEmpty(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (fuelNeeded > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public void Refuel(double liters)
        {
            if (liters > 0)
            {
                if (liters > this.tankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                    return;
                }
                else
                {
                    if (this.GetType().Name == "Truck")
                    {
                        liters *= 0.95;
                    }
                    this.FuelQuantity += liters;
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.fuelQuantity:f2}";
        }
    }
}
