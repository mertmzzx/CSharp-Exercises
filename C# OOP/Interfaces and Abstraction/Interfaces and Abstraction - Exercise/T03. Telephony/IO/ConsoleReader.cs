namespace Telephony.IO
{
    using System;
    using Interfaces;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            string text = Console.ReadLine();
            return text;
        }
    }
}
