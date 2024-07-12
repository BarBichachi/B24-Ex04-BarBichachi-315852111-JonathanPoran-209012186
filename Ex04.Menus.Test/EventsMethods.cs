using System;
using System.Threading;

namespace Ex04.Menus.Test
{
    public class EventsMethods
    {
        public static void ShowVersion()
        {
            Console.WriteLine("Version: 24.2.4.9504");
            Thread.Sleep(3000);
        }

        public static void CountCapitals()
        {
            Console.WriteLine("Please enter a line of text:");
            string input = Console.ReadLine();

            int uppercaseCount = countUppercaseLetters(input);
            Console.WriteLine($"The number of uppercase letters is: {uppercaseCount}");
            Thread.Sleep(3000);
        }

        private static int countUppercaseLetters(string input)
        {
            int numOfUpperLetters = 0;
            foreach (char c in input)
            {
                if (char.IsUpper(c))
                {
                    numOfUpperLetters++;
                }
            }
            return numOfUpperLetters;
        }

        public static void ShowTime()
        {
            Console.WriteLine($"The hour is {DateTime.Now:HH:mm:ss}");
            Thread.Sleep(3000);
        }

        public static void ShowDate()
        {
            Console.WriteLine($"The date is {DateTime.Now:dd/MM/yyyy}");
            Thread.Sleep(3000);
        }
    }
}
