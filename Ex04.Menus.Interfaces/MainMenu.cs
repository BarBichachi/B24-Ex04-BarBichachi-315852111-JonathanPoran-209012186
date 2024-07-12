using System;
using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : IMenuObserver
    {
        private readonly SubMenuItem r_MainMenu;
        public string EndMessage { get; set; }

        public MainMenu(string i_Title)
        {
            EndMessage = "You chose to exit, see you next time!";
            r_MainMenu = new SubMenuItem(i_Title);

            //TODO
            //AddActionMenuItem("Exit", new ExitExecutable());
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (i_MenuItem == null)
            {
                throw new ArgumentException("Menu item cannot be null.");
            }

            r_MainMenu.AddSubMenuItem(i_MenuItem);
            i_MenuItem.AttachObserver(this);
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            if (i_MenuItem == null)
            {
                throw new ArgumentException("Menu item cannot be null.");
            }

            r_MainMenu.RemoveSubMenuItem(i_MenuItem);
            i_MenuItem.DetachObserver(this);
        }

        public void Show()
        {
            try
            {
                r_MainMenu.Show();
                Console.Clear();
                Console.WriteLine(EndMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Thread.Sleep(3000);
        }

        public void MenuItemSelected(MenuItem i_MenuItem)
        {
            i_MenuItem.Show();
        }
    }
}