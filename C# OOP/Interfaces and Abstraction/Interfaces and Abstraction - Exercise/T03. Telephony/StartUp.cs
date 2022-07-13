namespace Telephony
{
    using System;
    using Core;
    using IO;
    using IO.Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Start();
        }
    }
}
