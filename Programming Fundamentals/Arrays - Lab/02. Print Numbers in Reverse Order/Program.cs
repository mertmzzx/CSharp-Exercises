using System;
using System.Linq;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(' ', array.Reverse()));


            //int[] reversedArray = new int[n];
            //
            //for (int i = 0; i < array.Length/2; i++)
            //{
            //    int temp = array[i];
            //    array[i] = array[array.Length - i - 1];
            //    array[array.Length - i - 1] = temp;
            //}
            //for (int i = 0; i < reversedArray.Length; i++)
            //{
            //    Console.Write(array[i] + " ");
            //}

            //for (int i = 0; i < array.Length; i++)
            //{
            //    reversedArray[i] = array[array.Length - i - 1];
            //}
            //
            //for (int i = 0; i < reversedArray.Length; i++)
            //{
            //    Console.Write(reversedArray[i] + " ");
            //}
        }
    }
}
