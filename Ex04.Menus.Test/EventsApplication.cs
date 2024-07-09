using System.Threading;
using System;

using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    internal class EventsApplication
    {
        private readonly MainMenu r_MainMenu = new MainMenu("Events Menu");

        public void Start()
        {
            MenuItem versionAndCapitalsMenu = new MenuItem("Version and Capitals");
            MenuItem showVersionItem = new MenuItem("Show Version", ShowVersion);
            MenuItem countCapitalsItem = new MenuItem("Count Capitals", CountCapitals);

            versionAndCapitalsMenu.AddMenuItem(showVersionItem);
            versionAndCapitalsMenu.AddMenuItem(countCapitalsItem);

            MenuItem showDateAndTimeMenu = new MenuItem("Show Date/Time");
            MenuItem showTimeItem = new MenuItem("Show Time", ShowTime);
            MenuItem showDateItem = new MenuItem("Show Date", ShowDate);

            showDateAndTimeMenu.AddMenuItem(showTimeItem);
            showDateAndTimeMenu.AddMenuItem(showDateItem);

            r_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            r_MainMenu.AddMenuItem(showDateAndTimeMenu);
            r_MainMenu.Show();
        }

        public void ShowVersion()
        {
            Console.WriteLine("Version");
            Thread.Sleep(3000);
        }

        public void CountCapitals()
        {
            Console.WriteLine("Count Capitals");
            Thread.Sleep(3000);
        }

        public void ShowTime()
        {
            Console.WriteLine("Time");
            Thread.Sleep(3000);
        }

        public void ShowDate()
        {
            Console.WriteLine("Date");
            Thread.Sleep(3000);
        }
    }
}