namespace VehiclesExtension.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }

        string Drive(double distance);

        void Refuel(double liters);
    }
}
