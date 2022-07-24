namespace Stealer4
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Stealer4.Hacker");
            Console.WriteLine(result);
        }
    }
}
