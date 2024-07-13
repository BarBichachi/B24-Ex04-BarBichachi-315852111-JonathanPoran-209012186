using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal static class InterfacesApplication
    {
        private static readonly MainMenu r_MainMenu = new MainMenu("Interface Menu");

        public static void Start()
        {
            SubMenuItem versionAndCapitalsMenu = new SubMenuItem("Version and Capitals");
            SubMenuItem showDateAndTimeMenu = new SubMenuItem("Show Date/Time");
            ActionMenuItem showVersionAction = new ActionMenuItem("Show Version", new InterfaceMethods.ShowVersion());
            ActionMenuItem countCapitalsAction = new ActionMenuItem("Count Capitals", new InterfaceMethods.CountCapitals());
            ActionMenuItem showTimeAction = new ActionMenuItem("Show Time", new InterfaceMethods.ShowTime());
            ActionMenuItem showDateAction = new ActionMenuItem("Show Date", new InterfaceMethods.ShowDate());

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