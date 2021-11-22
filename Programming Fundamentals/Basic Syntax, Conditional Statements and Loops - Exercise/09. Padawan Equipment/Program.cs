using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            
            double numberOfSabers = Math.Ceiling(studentsCount * 1.1);
            double numberOfBelts = Math.Floor(studentsCount / 6.0);

            double finalPriceForSabers = numberOfSabers * lightsabersPrice;
            double finalPriceForRobes = studentsCount * robesPrice;
            double finalPriceForBelts = (studentsCount - numberOfBelts) * beltsPrice;

            double totalPrice = finalPriceForSabers + finalPriceForRobes + finalPriceForBelts;

            if (amountOfMoney >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else if (amountOfMoney < totalPrice)
            {
                Console.WriteLine($"John will need {Math.Abs(totalPrice - amountOfMoney):F2}lv more.");
            }
        }
    }
}
