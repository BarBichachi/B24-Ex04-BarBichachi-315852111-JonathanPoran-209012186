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

            versionAndCapitalsMenu.AddActionMenuItem("Show Version", new InterfaceMethods.ShowVersion());
            versionAndCapitalsMenu.AddActionMenuItem("Count Capitals", new InterfaceMethods.CountCapitals());
            showDateAndTimeMenu.AddActionMenuItem("Show Time", new InterfaceMethods.ShowTime());
            showDateAndTimeMenu.AddActionMenuItem("Show Date", new InterfaceMethods.ShowDate());

            r_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            r_MainMenu.AddMenuItem(showDateAndTimeMenu);

            r_MainMenu.Show();
        }
    }
}