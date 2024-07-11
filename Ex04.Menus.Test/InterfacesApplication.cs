using System;
using System.Threading;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class InterfacesApplication
    {
        private readonly MainMenu r_MainMenu = new MainMenu("Interface Menu");

        public void Start()
        {
            MenuItem versionAndCapitalsMenu = new MenuItem("Version and Capitals");
            MenuItem showVersionItem = new MenuItem("Show Version", new ShowVersion());
            MenuItem countCapitalsItem = new MenuItem("Count Capitals", new CountCapitals());

            versionAndCapitalsMenu.AddMenuItem(showVersionItem);
            versionAndCapitalsMenu.AddMenuItem(countCapitalsItem);

            MenuItem showDateAndTimeMenu = new MenuItem("Show Date/Time");
            MenuItem showTimeItem = new MenuItem("Show Time", new ShowTime());
            MenuItem showDateItem = new MenuItem("Show Date", new ShowDate());

            showDateAndTimeMenu.AddMenuItem(showTimeItem);
            showDateAndTimeMenu.AddMenuItem(showDateItem);

            r_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            r_MainMenu.AddMenuItem(showDateAndTimeMenu);
            r_MainMenu.Show();
        }
    }

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
            DateTime now = DateTime.Now;
            Console.WriteLine($"The hour is {now.ToString("HH:mm:ss")}");
            Thread.Sleep(3000);
        }
    }

    public class ShowDate : IExecutable
    {
        public void Execute()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"The date is {now:dd:MM:yyyy}");
            Thread.Sleep(3000);
        }
    }
}
