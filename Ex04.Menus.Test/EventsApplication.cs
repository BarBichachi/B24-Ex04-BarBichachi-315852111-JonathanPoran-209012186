using System;
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

            versionAndCapitalsMenu.AddMenuItem(new MenuItem("Show Version", EventsMethods.ShowVersion));
            versionAndCapitalsMenu.AddMenuItem(new MenuItem("Count Capitals", EventsMethods.CountCapitals));
            showDateAndTimeMenu.AddMenuItem(new MenuItem("Show Time", EventsMethods.ShowTime));
            showDateAndTimeMenu.AddMenuItem(new MenuItem("Show Date", EventsMethods.ShowDate));
            r_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            r_MainMenu.AddMenuItem(showDateAndTimeMenu);
            r_MainMenu.Show();
        }
    }
}