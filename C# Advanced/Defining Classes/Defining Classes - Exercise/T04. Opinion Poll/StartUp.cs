using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();
                string name = data.Split()[0];
                int age = int.Parse(data.Split()[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            List<Person> olderThanThirty = family.FamilyMembers.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            foreach (var person in olderThanThirty)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

            //SECOND SOLUTION
            //int numberOfPeople = int.Parse(Console.ReadLine());
            //List<Person> peopleList = new List<Person>();
            //for (int i = 0; i < numberOfPeople; i++)
            //{
            //    string[] personData = Console.ReadLine().Split(' ');
            //    string name = personData[0];
            //    int age = int.Parse(personData[1]);

            //    Person person = new Person(name, age);
            //    peopleList.Add(person);
            //}

            //var sorted = peopleList.Where(person => person.Age > 30).OrderBy(person => person.Name).ToList();
            //sorted.ForEach(person => Console.WriteLine($"{person.Name} - {person.Age}"));
        }
    }
}
