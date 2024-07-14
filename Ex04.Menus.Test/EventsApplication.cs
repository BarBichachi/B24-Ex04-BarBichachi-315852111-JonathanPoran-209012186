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
            showVersionAction.m_Listeners += EventsMethods.ShowVersion;
            MenuItem countCapitalsAction = new MenuItem("Count Capitals");
            countCapitalsAction.m_Listeners += EventsMethods.CountCapitals;
            MenuItem showTimeAction = new MenuItem("Show Time");
            showTimeAction.m_Listeners += EventsMethods.ShowTime;
            MenuItem showDateAction = new MenuItem("Show Date");
            showDateAction.m_Listeners += EventsMethods.ShowDate;

            versionAndCapitalsMenu.AddMenuItem(showVersionAction);
            versionAndCapitalsMenu.AddMenuItem(countCapitalsAction);
            showDateAndTimeMenu.AddMenuItem(showTimeAction);
            showDateAndTimeMenu.AddMenuItem(showDateAction);
            r_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            r_MainMenu.AddMenuItem(showDateAndTimeMenu);
            r_MainMenu.Show();
        }
    }
}