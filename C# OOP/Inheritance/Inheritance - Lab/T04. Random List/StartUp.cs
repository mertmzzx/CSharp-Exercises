using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var newRandomList = new RandomList();

            newRandomList.Add("Pesho");
            newRandomList.Add("Gosho");
            newRandomList.Add("Svetlio");
            newRandomList.Add("Niki");
            newRandomList.Add("Kamen");

            newRandomList.RandomElement();

            Console.WriteLine(newRandomList.Count);
            Console.WriteLine(string.Join(", ", newRandomList));
        }
    }
}
