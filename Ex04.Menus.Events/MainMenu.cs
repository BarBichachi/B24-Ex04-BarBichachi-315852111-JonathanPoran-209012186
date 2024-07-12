using System.Threading;
using System;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly MenuItem r_MainMenu;
        public string EndMessage { get; set; }
        
        public MainMenu(string i_Title)
        {
            EndMessage = "You chose to exit, see you next time!";
            r_MainMenu = new MenuItem(i_Title);
            
            r_MainMenu.SubItems.Add(new MenuItem("Exit"));
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (i_MenuItem == null)
            {
                throw new ArgumentException("Menu item cannot be null.");
            }

            r_MainMenu.AddMenuItem(i_MenuItem);
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            if (i_MenuItem == null)
            {
                throw new ArgumentException("Menu item cannot be null.");
            }

            r_MainMenu.RemoveMenuItem(i_MenuItem);
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
    }
}