using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class EventsApplication
    {
        private readonly MainMenu r_MainMenu = new MainMenu("Events Menu");

        public void Start()
        {
            r_MainMenu.Show();
        }
    }
}
