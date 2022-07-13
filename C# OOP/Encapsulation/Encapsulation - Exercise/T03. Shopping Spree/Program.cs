using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> clients = new List<Person>();
                PeopleInp(clients);

                List<Product> products = new List<Product>();
                ProductInput(products);

                string cmd = Console.ReadLine();
                while (cmd != "END")
                {
                    string[] tokens = cmd.Split();

                    Person client = clients.Find(x => x.Name == tokens[0]);
                    Product product = products.Find(x => x.Name == tokens[1]);

                    if (client.Money >= product.Cost)
                    {
                        client.BagOfProducts.Add(product);
                        client.Money -= product.Cost;
                        Console.WriteLine($"{client.Name} bought {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{client.Name} can't afford {product.Name}");
                    }

                    cmd = Console.ReadLine();
                }

                foreach (var client in clients)
                {
                    Console.WriteLine(client);
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
          
        }

        public static void PeopleInp(List<Person> clients)
        {
            string[] people = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in people)
            {
                string[] arg = person.Split("=", StringSplitOptions.RemoveEmptyEntries);
                Person client = new Person(arg[0], decimal.Parse(arg[1]));
                clients.Add(client);
            }
        }

        public static void ProductInput(List<Product> products)
        {
            string[] items = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in items)
            {
                string[] arg = item.Split("=", StringSplitOptions.RemoveEmptyEntries);
                Product product = new Product(arg[0], decimal.Parse(arg[1]));
                products.Add(product);
            }
        }

        
    }
}
