namespace Telephony.Core
{
    using System;
    using IO.Interfaces;
    using Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly StationaryPhone stationaryPhone;
        private readonly Smartphone smartphone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string[] phoneNumbers = this.reader.Read().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = this.reader.Read().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in phoneNumbers)
            {
                if (!this.ValidateNumber(phoneNumber))
                {
                    this.writer.WriteLine("Invalid number!");
                }
                else if (phoneNumber.Length == 10)
                {
                    this.writer.WriteLine(this.smartphone.Call(phoneNumber));
                }
                else if (phoneNumber.Length == 7)
                {
                    this.writer.WriteLine(this.stationaryPhone.Call(phoneNumber));
                }
            }

            foreach (string url in urls)
            {
                if (!this.ValidateUrl(url))
                {
                    this.writer.WriteLine("Invalid URL!");
                }
                else
                {
                    this.writer.WriteLine(this.smartphone.Browse(url));
                }
            }
        }

        private bool ValidateNumber(string number)
        {
            foreach (var digit in number)
            {
                if (!Char.IsDigit(digit))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateUrl(string url)
        {
            foreach(var letter in url)
            {
                if (Char.IsDigit(letter))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
