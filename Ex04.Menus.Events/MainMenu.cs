using System.Threading;
using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly MenuItem r_MainMenu;
        public string EndMessage { get; set; }

        public MainMenu(string i_Title)
        {
            r_MainMenu = new MenuItem(i_Title);
            EndMessage = "You chose to exit, see you next time!";
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MainMenu.AddMenuItem(i_MenuItem);
        }

        public void Show()
        {
            Console.Clear();
            showMainMenu();
            Console.WriteLine(EndMessage);
            Thread.Sleep(3000);
        }

        private void showMainMenu()
        {
            List<MenuItem> mainMenuSubItems = r_MainMenu.SubItems;
            bool isFinished = false;

            do
            {
                int userChoice = r_MainMenu.GetValidOption(mainMenuSubItems, "Exit");

                if (userChoice != 0)
                {
                    mainMenuSubItems[userChoice - 1].OnChosen();
                }
                else
                {
                    isFinished = true;
                }
            } while (!isFinished);
        }
    }
}