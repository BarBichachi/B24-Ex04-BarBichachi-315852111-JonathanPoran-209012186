using System;
using System.Collections.Generic;
using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly string r_MainMenuTitle;
        private readonly List<MenuItem> r_MainMenuSubItems;
        public string EndMessage { get; set; }

        public MainMenu(string i_Title)
        {
            EndMessage = "You chose to exit, see you next time!";
            r_MainMenuTitle = i_Title;
            r_MainMenuSubItems = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MainMenuSubItems.Add(i_MenuItem);
            i_MenuItem.m_chooseNoitifier += new Action<MenuItem>(this.hendelSubMenu);
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            r_MainMenuSubItems.Remove(i_MenuItem);
        }

        public void Show()
        {
            int userChoice;

            do
            {
                Console.Clear();
                Console.WriteLine($"===== {r_MainMenuTitle} =====");    

                printSubItems(r_MainMenuSubItems);

                Console.WriteLine("0. Exit");

                userChoice = getValidOption(r_MainMenuSubItems);

                if (userChoice != 0)
                {
                    r_MainMenuSubItems[userChoice].DoChooseItem();
                }
            } while (userChoice != 0);
        }

        private int getValidOption(List<MenuItem> i_SubItems)
        {
            bool isValid = false;
            int numericChoice;
            int numberOfSubItems = i_SubItems.Count;
            do
            {
                Console.Write($"Please enter your choice (1-{numberOfSubItems} or 0 to exit): ");

                string userChoice = Console.ReadLine();

                if (!int.TryParse(userChoice, out numericChoice))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid integer.");
                }
                else
                {
                    isValid = numericChoice >= 0 && numericChoice <= (numberOfSubItems);

                    if (!isValid)
                    {
                        Console.WriteLine($"You can only choose between 0 and {numberOfSubItems}. try again.");
                    }
                }
            } while (!isValid);

            return numericChoice;
        }

        private void printSubItems(List<MenuItem> i_SubItems)
        {
            int numOption = 1;

            foreach(MenuItem menuItem in i_SubItems)
            {
                Console.WriteLine($"{numOption}. {menuItem.ToString}");
                numOption++;
            }
        }

        public void ob()
        {

        }
        private void hendelSubMenu(MenuItem i_SubMenu)
        {
            int userChoice;

            do
            {
                Console.Clear();
                Console.WriteLine($"===== {i_SubMenu.ToString} =====");    
                
                printSubItems(i_SubMenu.SubItems);
                
                Console.WriteLine("0. Back");

                userChoice = getValidOption(i_SubMenu.SubItems);

                if (userChoice != 0)
                {
                    r_MainMenuSubItems[userChoice].DoChooseItem();
                }
            } while (userChoice != 0);
        }
    }
}