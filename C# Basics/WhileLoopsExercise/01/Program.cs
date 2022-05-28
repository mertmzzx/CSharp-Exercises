using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string theBook = Console.ReadLine();
            string books;
            int searchedBooks = 1;

            while (true)
            {
                books = Console.ReadLine();

                if (books == theBook)
                {
                    Console.WriteLine($"You checked {searchedBooks} books and found it.");
                    break;
                }
                if (books == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {searchedBooks} books.");
                    break;
                }

                searchedBooks++;
            }
        }
    }
}
