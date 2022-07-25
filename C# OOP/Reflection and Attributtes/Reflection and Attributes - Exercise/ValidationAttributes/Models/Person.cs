namespace ValidationAttributes.Models
{
    using Utilities.Attributes;

    public class Person
    {
        private const int MinAgeValue = 12;
        private const int MaxAgeValue = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(MinAgeValue, MaxAgeValue)]
        public int Age { get; set; }
    }
}
