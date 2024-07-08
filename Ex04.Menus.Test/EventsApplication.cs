using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class EventsApplication
    {
        private MainMenu m_MainMenu = new MainMenu("Events Menu");

        public void Start()
        {
            m_MainMenu.Show();
        }
    }
}
