using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        //fields
        private List<Person> familyMembers;

        //constructor
        public Family()
        {
            this.familyMembers = new List<Person>();

        }

        //methods (functions)
        public void AddMember(Person member)
        {
            this.familyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = this.familyMembers.Max(member => member.Age);
            return this.familyMembers.First(member => member.Age == maxAge);
        }
    }
}