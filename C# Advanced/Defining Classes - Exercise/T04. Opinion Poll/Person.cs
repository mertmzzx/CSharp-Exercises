namespace DefiningClasses
{
    public class Person
    {
        //fields
        private string name;
        int age;

        //constructor by default
        public Person()
        {
            Name = "No Name";
            Age = 1;
        }

        //constructor only with age
        public Person(int age)
        {
            Name = "No Name";
            Age = age;
        }

        //constructor with parameters 
        public Person(string name, int age)
        {
            //new empty object
            Name = name;
            Age = age;
        }

        //properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}