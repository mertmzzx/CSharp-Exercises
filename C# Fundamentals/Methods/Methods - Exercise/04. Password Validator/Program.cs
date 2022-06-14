using System;
using System.Linq;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            //It should contain 6 – 10 characters (inclusive)
            //It should contain only of letters and digits
            //It should contain at least 2 digits


            bool passwordLength = PasswordLength(password);
            bool passwordLettersOrDigits = PasswordLettersOrDigits(password);
            bool passwordDigits = PasswordDigits(password);

            if (passwordLength && passwordLettersOrDigits && passwordDigits)
            {
                Console.WriteLine("Password is valid");
            }

            if (!passwordLength)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!passwordLettersOrDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!passwordDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            static bool PasswordLength(string password)
            {
                bool isValid = false;

                if (password.Length > 6 && password.Length <= 10)
                {
                    isValid = true;
                }

                return isValid;
            }

            static bool PasswordDigits(string password)
            {
                bool isMoreThanTwo = false;
                int count = 0;

                for (int i = 0; i < password.Length; i++)
                {
                    if ("1234567890".Contains(password[i]))
                    {
                        count++;
                    }
                }

                if (count >= 2)
                {
                    isMoreThanTwo = true;
                }

                return isMoreThanTwo;
            }

            static bool PasswordLettersOrDigits(string password)
            {
                bool lettersOrDigits = true;

                for (int i = 0; i < password.Length; i++)
                {
                    if (!password.All(Char.IsLetterOrDigit))
                    {
                        lettersOrDigits = false;
                    }
                }

                return lettersOrDigits;
            }
        }
    }
}