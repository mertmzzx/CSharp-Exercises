using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int[] copiedArr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                copiedArr[i] = arr[i];
            }

            Console.WriteLine("The elements stored in the first array are : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();

            Console.WriteLine("The elements copied into the second array are : ");
            for (int i = 0; i < copiedArr.Length; i++)
            {
                Console.Write($"{copiedArr[i]} ");
            }
        }
    }
}
