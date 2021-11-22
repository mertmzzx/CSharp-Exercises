using System;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double commission = 0.0;

            switch (city)
            {
                case "Sofia":
                    if (0 <= sales && sales <= 500)
                    {
                        commission = sales * 0.05;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else if (500 < sales && sales <= 1000)
                    {
                        commission = sales * 0.07;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else if (1000 < sales && sales <= 10000)
                    {
                        commission = sales * 0.08;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else if (sales > 10000)
                    {
                        commission = sales * 0.12;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Varna":
                    if (0 <= sales && sales <= 500)
                    {
                        commission = sales * 0.045;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else if (500 < sales && sales <= 1000)
                    {
                        commission = sales * 0.075;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else if (1000 < sales && sales <= 10000)
                    {
                        commission = sales * 0.10;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else if (sales > 10000)
                    {
                        commission = sales * 0.13;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Plovdiv":
                    if (0 <= sales && sales <= 500)
                    {
                        commission = sales * 0.055;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else if (500 < sales && sales <= 1000)
                    {
                        commission = sales * 0.08;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else if (1000 < sales && sales <= 10000)
                    {
                        commission = sales * 0.12;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else if (sales > 10000)
                    {
                        commission = sales * 0.145;
                        Console.WriteLine($"{commission:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
