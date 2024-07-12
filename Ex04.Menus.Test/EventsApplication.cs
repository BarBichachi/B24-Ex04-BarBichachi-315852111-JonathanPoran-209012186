using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    internal class EventsApplication
    {
        private readonly MainMenu r_MainMenu = new MainMenu("Events Menu");

        public void Start()
        { 
            MenuItem versionAndCapitalsMenu = new MenuItem("Version and Capitals");
            versionAndCapitalsMenu.AddMenuItem(new MenuItem("Show Version", EventsMethods.ShowVersion));
            versionAndCapitalsMenu.AddMenuItem(new MenuItem("Count Capitals", EventsMethods.CountCapitals));

            MenuItem showDateAndTimeMenu = new MenuItem("Show Date/Time");
            showDateAndTimeMenu.AddMenuItem(new MenuItem("Show Time", EventsMethods.ShowTime));
            showDateAndTimeMenu.AddMenuItem(new MenuItem("Show Date", EventsMethods.ShowDate));

            r_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            r_MainMenu.AddMenuItem(showDateAndTimeMenu);
            r_MainMenu.Show();
        }
    }
}