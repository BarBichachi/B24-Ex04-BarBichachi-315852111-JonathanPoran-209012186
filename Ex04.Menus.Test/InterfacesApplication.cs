using System.Threading;
using System;

using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class InterfacesApplication : IMethodListener
    {
        private static readonly MainMenu sr_MainMenu = new MainMenu("Interface Menu");

        public void Start()
        {
            MenuItem versionAndCapitalsMenu = new MenuItem("Version and Capitals");
            MenuItem showDateAndTimeMenu = new MenuItem("Show Date/Time");

            versionAndCapitalsMenu.AddMenuItem(new MenuItem("Show Version", this));
            versionAndCapitalsMenu.AddMenuItem(new MenuItem("Count Capitals", this));
            showDateAndTimeMenu.AddMenuItem(new MenuItem("Show Time", this));
            showDateAndTimeMenu.AddMenuItem(new MenuItem("Show Date", this));
            sr_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            sr_MainMenu.AddMenuItem(showDateAndTimeMenu);
            sr_MainMenu.Show();
        }

        public void chosenMethod(string i_MenuItemTitle)
        {
            if (i_MenuItemTitle == "Show Version")
            {
                ShowVersion();
            }
            else if (i_MenuItemTitle == "Count Capitals")
            {
                CountCapitals();
            }
            else if (i_MenuItemTitle == "Show Time")
            {
                ShowTime();
            }
            else if (i_MenuItemTitle == "Show Date")
            {
                ShowDate();
            }

        }

        private static void ShowVersion()
        {
            Console.WriteLine("Version: 24.2.4.9504");
            Thread.Sleep(3000);
        }

        private static void CountCapitals()
        {
            Console.WriteLine("Please enter a line of text:");

            string input = Console.ReadLine();
            int uppercaseCount = countUppercaseLetters(input);

            Console.WriteLine($"The number of uppercase letters is: {uppercaseCount}");
            Thread.Sleep(3000);
        }

        private static int countUppercaseLetters(string i_Input)
        {
            int numOfUpperLetters = 0;

            foreach (char currentChar in i_Input)
            {
                if (char.IsUpper(currentChar))
                {
                    numOfUpperLetters++;
                }
            }

            return numOfUpperLetters;
        }

        private static void ShowTime()
        {
            Console.WriteLine($"The hour is {DateTime.Now.ToString("HH:mm:ss")}");
            Thread.Sleep(3000);
        }

        private static void ShowDate()
        {
            Console.WriteLine($"The date is {DateTime.Now:dd/MM/yyyy}");
            Thread.Sleep(3000);
        }
    }
}