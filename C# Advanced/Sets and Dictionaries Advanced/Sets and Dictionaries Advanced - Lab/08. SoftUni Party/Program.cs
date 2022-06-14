using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();

            string people = Console.ReadLine();
            AddGuests(vip, regular, people);

            people = Console.ReadLine();
            ClearGuests(vip, regular, people);

            int count = vip.Count + regular.Count;
            Console.WriteLine(count);

            if (vip.Count > 0)
            {
                foreach (var guest in vip)
                {
                    Console.WriteLine(guest);
                }
            }
            if (regular.Count > 0)
            {
                foreach (var guest in regular)
                {
                    Console.WriteLine(guest);
                }
            }
        }

        static void ClearGuests(HashSet<string> vip, HashSet<string> regular, string people)
        {
            while (people != "END")
            {
                if (char.IsDigit(people[0]))
                {
                    if (vip.Contains(people))
                    {
                        vip.Remove(people);
                    }
                }
                else
                {
                    if (regular.Contains(people))
                    {
                        regular.Remove(people);
                    }
                }

                people = Console.ReadLine();
            }
        }

        static void AddGuests(HashSet<string> vip, HashSet<string> regular, string people)
        {
            while (people != "PARTY")
            {
                if (char.IsDigit(people[0]))
                {
                    if (!vip.Contains(people))
                    {
                        vip.Add(people);
                    }
                }
                else
                {
                    if (!regular.Contains(people))
                    {
                        regular.Add(people);
                    }
                }

                people = Console.ReadLine();
            }
        }
    }
}
