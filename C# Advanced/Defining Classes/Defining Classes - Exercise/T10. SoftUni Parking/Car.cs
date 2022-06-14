using System;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        //Fields
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        //Properties
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public string RegistrationNumber { get { return registrationNumber; } set { registrationNumber = value; } }
        

        //Constructor
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        //override method ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Make: {Make}").Append(Environment.NewLine);
            sb.Append($"Model: {Model}").Append(Environment.NewLine);
            sb.Append($"HorsePower: {HorsePower}").Append(Environment.NewLine);
            sb.Append($"RegistrationNumber: {RegistrationNumber}");

            return sb.ToString();
        }
    }
}
