using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());

            double money = double.Parse(Console.ReadLine());


            string action = "";

            double actionMoney = 0.00;


            int spendingCounter = 0;

            int dayCounter = 0;


            while (true)
            {
                action = Console.ReadLine();
                actionMoney = double.Parse(Console.ReadLine());

                if (action == "save")
                {
                    money += actionMoney;
                    spendingCounter = 0;
                }
                else
                {
                    money -= actionMoney;
                    spendingCounter++;

                    if (actionMoney > money)
                    {
                        money = 0;
                    }
                }

                dayCounter++;

                if (money >= tripPrice)
                {
                    Console.WriteLine($"You saved the money for {dayCounter} days.");
                    break;
                }
                if (spendingCounter == 5)
                {
                    Console.WriteLine($"You can't save the money.");
                    Console.WriteLine(dayCounter);
                    break;
                }
            }
        }
    }
}
