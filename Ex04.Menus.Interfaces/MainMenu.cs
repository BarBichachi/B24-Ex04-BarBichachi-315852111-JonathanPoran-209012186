using System;
using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : IMenu
    {
        private readonly MenuItem r_MainMenu;

        public MainMenu(string i_Title)
        {
            r_MainMenu = new MenuItem(i_Title);
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MainMenu.r_SubItems.Add(i_MenuItem);
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            r_MainMenu.r_SubItems.Remove(i_MenuItem);
        }

        public void Show()
        {
            if (r_MainMenu.r_SubItems.Count == 0)
            {
                Console.WriteLine("You forgot to enter items to your main menu!");
            }
            else
            {
                int userChoice = -1;

                while (userChoice != 0)
                {
                    r_MainMenu.PrintMenuSubItems();
                    Console.WriteLine("0. Exit");

                    userChoice = r_MainMenu.getValidMenuOption(r_MainMenu.r_SubItems.Count);

                    if (userChoice != 0)
                    {
                        r_MainMenu.r_SubItems[userChoice - 1].Show();
                    }
                }

                Console.Clear();
                Console.WriteLine("You chose to exit, goodbye!");
                Thread.Sleep(3000);
            }
        }
    }
}