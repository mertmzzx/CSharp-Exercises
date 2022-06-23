using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Participants = new List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public List<Car> Participants { get; set; }
        public int Count => Participants.Count;
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public void Add(Car car)
        {
            //bool exists = false;
            //foreach (var racer in Participants)
            //{
            //    if (racer.LicensePlate == car.LicensePlate)
            //    {
            //        exists = true;
            //    }
            //}

            //if (exists && Count < Capacity && car.HorsePower <= MaxHorsePower)
            //{
            //    Participants.Add(car);
            //}

            if (Participants.All(x => x.LicensePlate != car.LicensePlate) && Count < Capacity && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            //Car car = Participants.Find(x => x.LicensePlate == licensePlate);

            //if (car == null)
            //{
            //    return false;
            //}
            //else
            //{
            //    Participants.Remove(car);
            //    return true;
            //}

            bool isRemoved = false;

            foreach (var car in Participants)
            {
                if (car.LicensePlate == licensePlate)
                {
                    Participants.Remove(car);
                    isRemoved = true;
                    break;
                }
            }

            return isRemoved;
        }

        public Car FindParticipant(string licensePlate)
        {
            foreach (var car in Participants)
            {
                if (car.LicensePlate == licensePlate)
                {
                    return car;
                }
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            //if (!Participants.Any())
            //{
            //    return null;
            //}

            //var car = Participants.Max(m => m.HorsePower);
            //var mostPowerfulCar = Participants.Find(mostPowerfulCar => mostPowerfulCar.HorsePower == car);

            //if (mostPowerfulCar == null)
            //{
            //    return null;
            //}
            //else
            //{
            //    return mostPowerfulCar;
            //}

            Car mostPowerfulCar = null;
            if (Count > 0)
            {
                int mostPowerful = 0;

                foreach (var car in Participants)
                {
                    if (car.HorsePower > mostPowerful)
                    {
                        mostPowerful = car.HorsePower;
                        mostPowerfulCar = car;
                    }
                }

                return mostPowerfulCar;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            sb.AppendLine(string.Join(Environment.NewLine, Participants));

            return sb.ToString().TrimEnd();
        }
    }
}
