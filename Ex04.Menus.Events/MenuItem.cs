using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        private readonly string r_Title;
        internal List<MenuItem>? SubItems { get; }
        private Action? Action { get; }

        public MenuItem(string i_Title, Action i_Action = null)
        {
            r_Title = i_Title;
            Action = i_Action;
            
            if (i_Action == null)
            {
                SubItems = new List<MenuItem>();
            }
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (Action != null)
            {
                Console.WriteLine("This is an executable item!");
            }
            else
            {
                if (SubItems != null && SubItems.Count == 0)
                {
                    SubItems.Add(new MenuItem("Back"));
                }

                SubItems?.Add(i_MenuItem);
            }
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            if (Action != null)
            {
                Console.WriteLine("This is an executable item!");
            }
            else
            {
                if (SubItems != null)
                {
                    SubItems.Remove(i_MenuItem);
                }
                else
                {
                    Console.WriteLine("Can't remove from empty list.");
                }
            }
        }

        public void Show()
        {
            if (Action != null)
            {
                Action.Invoke();
            }
            else
            {
                int userChoice = -1;

                while (userChoice != 0)
                {
                    PrintMenuSubItems();

                    if (SubItems != null)
                    {
                        userChoice = GetValidMenuOption(SubItems.Count - 1);

                        if (userChoice != 0)
                        {
                            SubItems[userChoice].Show();
                        }
                    }
                }
            }
        }

        internal void PrintMenuSubItems()
        {
            Console.Clear();
            Console.WriteLine($"===== {r_Title} =====");

            if (SubItems != null)
            {
                for (int i = 1; i < SubItems.Count; i++)
                {
                    Console.WriteLine($"{i}. {SubItems[i].r_Title}");
                }

                Console.WriteLine($"0. {SubItems[0].r_Title}");
            }
        }

        internal static int GetValidMenuOption(int i_MaximumChoice)
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
                        Console.WriteLine($"You can only choose between 0 and {i_MaximumChoice}. Try again.");
                    }
                }
            } while (!isValid);

            return numericChoice;
        }
    }
}
