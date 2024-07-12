using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal static class InterfacesApplication
    {
        private static readonly MainMenu r_MainMenu = new MainMenu("Interface Menu");

        public static void Start()
        {
            MenuItem versionAndCapitalsMenu = new MenuItem("Version and Capitals");
            MenuItem showDateAndTimeMenu = new MenuItem("Show Date/Time");

            versionAndCapitalsMenu.AddMenuItem(new MenuItem("Show Version", new InterfaceMethods.ShowVersion()));
            versionAndCapitalsMenu.AddMenuItem(new MenuItem("Count Capitals", new InterfaceMethods.CountCapitals()));
            showDateAndTimeMenu.AddMenuItem(new MenuItem("Show Time", new InterfaceMethods.ShowTime()));
            showDateAndTimeMenu.AddMenuItem(new MenuItem("Show Date", new InterfaceMethods.ShowDate()));
            r_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            r_MainMenu.AddMenuItem(showDateAndTimeMenu);
            r_MainMenu.Show();
        }
    }
}