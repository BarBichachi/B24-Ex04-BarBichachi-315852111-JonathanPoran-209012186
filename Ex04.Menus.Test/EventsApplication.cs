using System;
using System.Threading;

using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    internal static class EventsApplication
    {
        private static readonly MainMenu r_MainMenu = new MainMenu("Events Menu");

        public static void Start()
        {
            MenuItem versionAndCapitalsMenu = new MenuItem("Version and Capitals");
            MenuItem showDateAndTimeMenu = new MenuItem("Show Date/Time");
            MenuItem showVersionAction = new MenuItem("Show Version");
            showVersionAction.m_Listeners += menuItem_Chosen;
            MenuItem countCapitalsAction = new MenuItem("Count Capitals");
            countCapitalsAction.m_Listeners += menuItem_Chosen;
            MenuItem showTimeAction = new MenuItem("Show Time");
            showTimeAction.m_Listeners += menuItem_Chosen;
            MenuItem showDateAction = new MenuItem("Show Date");
            showDateAction.m_Listeners += menuItem_Chosen;

            versionAndCapitalsMenu.AddMenuItem(showVersionAction);
            versionAndCapitalsMenu.AddMenuItem(countCapitalsAction);
            showDateAndTimeMenu.AddMenuItem(showTimeAction);
            showDateAndTimeMenu.AddMenuItem(showDateAction);
            r_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            r_MainMenu.AddMenuItem(showDateAndTimeMenu);
            r_MainMenu.Show();
        }

        private static void menuItem_Chosen(string i_MenuItemTitle)
        {
            switch (i_MenuItemTitle)
            {
                case "Show Version":
                    showVersion();
                    break;
                case "Count Capitals":
                    countCapitals();
                    break;
                case "Show Time":
                    showTime();
                    break;
                case "Show Date":
                    showDate();
                    break;
                default:
                    throw new Exception($"MenuItem Title '{i_MenuItemTitle}' does not match any known method names");
            }
        }

        private static void showVersion()
        {
            Console.WriteLine("Version: 24.2.4.9504");
            Thread.Sleep(3000);
        }

        private static void countCapitals()
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

        private static void showTime()
        {
            Console.WriteLine($"The hour is {DateTime.Now:HH:mm:ss}");
            Thread.Sleep(3000);
        }

        private static void showDate()
        {
            Console.WriteLine($"The date is {DateTime.Now:dd/MM/yyyy}");
            Thread.Sleep(3000);
        }
    }
}