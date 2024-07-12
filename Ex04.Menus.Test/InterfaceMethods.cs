using System;
using System.Threading;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceMethods 
    {
        public class ShowVersion : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine("Version: 24.2.4.9504");
                Thread.Sleep(3000);
            }
        }

        public class CountCapitals : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine("Please enter a line of text:");
                string input = Console.ReadLine();

                int uppercaseCount = countUppercaseLetters(input);
                Console.WriteLine($"The number of uppercase letters is: {uppercaseCount}");
                Thread.Sleep(3000);
            }

            private int countUppercaseLetters(string i_Input)
            {
                int numOfUpperLetters = 0;
                foreach (char c in i_Input)
                {
                    if (char.IsUpper(c))
                    {
                        numOfUpperLetters++;
                    }
                }
                return numOfUpperLetters;
            }
        }

        public class ShowTime : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine($"The hour is {DateTime.Now.ToString("HH:mm:ss")}");
                Thread.Sleep(3000);
            }
        }

        public class ShowDate : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine($"The date is {DateTime.Now:dd/MM/yyyy}");
                Thread.Sleep(3000);
            }
        }
    }
}