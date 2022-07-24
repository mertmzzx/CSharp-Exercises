namespace Stealer2
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAccessModifiers("Stealer2.Hacker");
            Console.WriteLine(result);
        }
    }
}
