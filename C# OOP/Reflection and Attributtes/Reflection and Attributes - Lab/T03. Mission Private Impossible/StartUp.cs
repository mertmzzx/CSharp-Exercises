namespace Stealer3
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Stealer3.Hacker");
            Console.WriteLine(result);
        }
    }
}
