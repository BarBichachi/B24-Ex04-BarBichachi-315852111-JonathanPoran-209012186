using System;
using System.Threading;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.InterfaceMethods
{
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
}