using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    using Interfaces;
    public class Pet : IAnimal, IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
