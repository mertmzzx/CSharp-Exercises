using System;
using System.Linq;

namespace T03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> minNum = nums => nums.Min();

            Console.WriteLine(minNum(nums));
        }
    }
}
