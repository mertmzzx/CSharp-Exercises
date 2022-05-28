using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double rose = 5;
            double dahlia = 3.80;
            double tulip = 2.80;
            double narcissus = 3;
            double gladiolus = 2.50;

            double totalPrice = 0;

            switch (flower)
            {
                case "Roses":
                    totalPrice = amount * rose;

                    if (amount > 80)
                    {
                        totalPrice = totalPrice - (totalPrice * 0.1);
                    }
                    else
                    {
                        totalPrice = amount * rose;
                    }
                    break;
                case "Dahlias":
                    totalPrice = amount * dahlia;

                    if (amount > 90)
                    {
                        totalPrice = totalPrice - (totalPrice * 0.15);
                    }
                    else
                    {
                        totalPrice = amount * dahlia;
                    }
                    break;
                case "Tulips":
                    totalPrice = amount * tulip;

                    if (amount > 80)
                    {
                        totalPrice = totalPrice - (totalPrice * 0.15);
                    }
                    else
                    {
                        totalPrice = amount * tulip;
                    }
                    break;
                case "Narcissus":
                    totalPrice = amount * narcissus;

                    if (amount < 120)
                    {
                        totalPrice = totalPrice + (totalPrice * 0.15);
                    }
                    else
                    {
                        totalPrice = amount * narcissus;
                    }
                    break;
                case "Gladiolus":
                    totalPrice = amount * gladiolus;

                    if (amount < 80)
                    {
                        totalPrice = totalPrice + (totalPrice * 0.20);
                    }
                    else
                    {
                        totalPrice = amount * gladiolus;
                    }
                    break;
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {amount} {flower} and {budget-totalPrice:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(totalPrice-budget):F2} leva more.");
            }
        }
    }
}
