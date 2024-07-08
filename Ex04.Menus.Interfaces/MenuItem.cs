using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenu
    {
        public string Title { get; set; }
        internal readonly List<MenuItem> r_SubItems;
        private object Executable { get; set; }

        public MenuItem(string i_Title, IExecutable i_Executable)
        {
            Title = i_Title;
            Executable = i_Executable;
        }

        public MenuItem(string i_Title)
        {
            Title = i_Title;
            r_SubItems = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (r_SubItems == null)
            {
                Console.WriteLine("This is an executable item!");
            }
            else
            {
                r_SubItems.Add(i_MenuItem);
            }
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            if (r_SubItems == null)
            {
                Console.WriteLine("This is an executable item!");
            }
            else
            {
                r_SubItems.Remove(i_MenuItem);
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
                if (r_SubItems.Count == 0)
                {
                    Console.WriteLine($"You forgot to enter sub-items to {Title}");
                }
                int userChoice = -1;

                while (userChoice != 0)
                {
                    PrintMenuSubItems();
                    Console.WriteLine("0. Back");

                    userChoice = getValidMenuOption(r_SubItems.Count);

                    if (userChoice != 0)
                    {
                        r_SubItems[userChoice - 1].Show();
                    }
                }
            }
        }

        internal void PrintMenuSubItems()
        {
            Console.Clear();
            Console.WriteLine($"===== {Title} =====");

            for (int i = 0; i < r_SubItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {r_SubItems[i].Title}");
            }
        }

        internal int getValidMenuOption(int i_MaximumChoice)
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
