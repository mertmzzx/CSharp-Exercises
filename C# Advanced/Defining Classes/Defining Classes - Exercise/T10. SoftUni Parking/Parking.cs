using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    class Parking
    {
        //Fields
        private List<Car> cars;
        private int capacity;

        //Properties
        public List<Car> Cars { get {return cars; } set {cars = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int Count { get { return Cars.Count; } }

        //Constructor
        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }

        //Methods
        public string AddCar(Car addedCar)
        {
            bool canAddCar = true;
            foreach (Car car in Cars)
            {
                if (car.RegistrationNumber == addedCar.RegistrationNumber)
                {
                    canAddCar = false;
                    return "Car with that registration number, already exists!";
                }
            }

            if (Cars.Count + 1 > capacity)
            {
                canAddCar = false;
                return "Parking is full!";
            }

            if (canAddCar)
            {
                Cars.Add(addedCar);
                return $"Successfully added new car {addedCar.Make} {addedCar.RegistrationNumber}";
            }

            return "";
        }

        public string RemoveCar(string registrationNumber)
        {
            bool isParked = false;
            foreach (Car car in Cars)
            {
                if (car.RegistrationNumber == registrationNumber)
                {
                    isParked = true;
                }
            }

            if (!isParked)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car carToRemove = Cars.First(car => car.RegistrationNumber == registrationNumber);
                Cars.Remove(carToRemove);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.First(car => car.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                RemoveCar(regNumber);
            }
        }
    }
}
