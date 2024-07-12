using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class InterfacesApplication
    {
        private readonly MainMenu r_MainMenu = new MainMenu("Interface Menu");

        public void Start()
        {
            MenuItem versionAndCapitalsMenu = new MenuItem("Version and Capitals");
            versionAndCapitalsMenu.AddMenuItem(new MenuItem("Show Version", new InterfaceMethods.ShowVersion()));
            versionAndCapitalsMenu.AddMenuItem(new MenuItem("Count Capitals", new InterfaceMethods.CountCapitals()));

            MenuItem showDateAndTimeMenu = new MenuItem("Show Date/Time");
            showDateAndTimeMenu.AddMenuItem(new MenuItem("Show Time", new InterfaceMethods.ShowTime()));
            showDateAndTimeMenu.AddMenuItem(new MenuItem("Show Date", new InterfaceMethods.ShowDate()));

            r_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            r_MainMenu.AddMenuItem(showDateAndTimeMenu);
            r_MainMenu.Show();
        }
    }
}