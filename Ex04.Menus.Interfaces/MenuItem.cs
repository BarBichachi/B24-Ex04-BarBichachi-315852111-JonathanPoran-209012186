using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenu
    {
        private string Title { get; set; }
        private readonly List<MenuItem> SubItems;
        private object Executable { get; set; }

        public MenuItem(string i_Title, IExecutable i_Executable)
        {
            Title = i_Title;
            Executable = i_Executable;
        }

        public MenuItem(string i_Title)
        {
            Title = i_Title;
            SubItems = new List<MenuItem>();
        }

        public void AddMenuItem(string i_Title, IExecutable i_Executable)
        {
            MenuItem newMenuItem = new MenuItem(i_Title, i_Executable);
            AddMenuItem(newMenuItem);
        }

        // MainMenu listen to 1....9
        // 7 notify chosen to MainMenu



        // MainMenu prints the menu
        // 7 is chosen
        // 7 prints the menu
        // 2 is chosen (print triangle)
        // 2 notify 7 -> print menu again
        // 7 notify menu (back was pressed)
        // MainMenu prints the menu

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (SubItems == null)
            {
                Console.WriteLine("This is an executable item!");
            }
            else
            {
                SubItems.Add(i_MenuItem);
            }
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            if (SubItems == null)
            {
                Console.WriteLine("This is an executable item!");
            }
            else
            {
                SubItems.Remove(i_MenuItem);
            }
        }

        public void Show()
        {
            if (Executable is IExecutable executableItem)
            {
                executableItem.Execute();
            }
            else
            {
                if (SubItems.Count == 0)
                {
                    Console.WriteLine($"You forgot to enter sub-items to {Title}");
                }
                int userChoice = -1;

                while (userChoice != 0)
                {
                    PrintMenuSubItems();
                    Console.WriteLine("0. Back");

                    userChoice = GetValidMenuOption(SubItems.Count);

                    if (userChoice != 0)
                    {
                        SubItems[userChoice - 1].Show();
                    }
                }
            }
        }

        internal void PrintMenuSubItems()
        {
            Console.Clear();
            Console.WriteLine($"===== {Title} =====");

            for (int i = 0; i < SubItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {SubItems[i].Title}");
            }
        }

        internal int GetValidMenuOption(int i_MaximumChoice)
        {
            bool isValid = false;
            int numericChoice;

            do
            {
                Console.Write($"Please enter your choice (1-{i_MaximumChoice} or 0 to exit): ");

                string userChoice = Console.ReadLine();

                if (!int.TryParse(userChoice, out numericChoice))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid integer.");
                }
                else
                {
                    isValid = numericChoice >= 0 && numericChoice <= i_MaximumChoice;

                    if (!isValid)
                    {
                        Console.WriteLine($"You can only choose between 0 and {i_MaximumChoice}. try again.");
                    }
                }
            } while (!isValid);

            return numericChoice;
        }
    }
}
