using System.Collections.Generic;
using System.Text;

namespace Telephony.Models
{
    using System;
    using Interfaces;
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            //if (!this.ValidateNumber(number))
            //{
            //    return "Invalid number!";
            //}

            return $"Dialing... {number}";
        }

       
    }
}
