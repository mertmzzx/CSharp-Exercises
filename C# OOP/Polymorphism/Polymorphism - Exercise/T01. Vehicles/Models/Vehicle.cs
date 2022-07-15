namespace Vehicles.Models
{
    using Models.Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuentity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuentity;
            this.FuelConsumption = fuelConsumption;
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

        protected virtual double FuelConsumptionModifier { get; }

        public string Drive(double distance)
        {
            double fueldNeeded = distance * this.FuelConsumption;

            if (fueldNeeded > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= fueldNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.fuelQuantity:f2}";
        }
    }
}
