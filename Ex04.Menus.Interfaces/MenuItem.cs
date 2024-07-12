using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenu
    {
        private readonly string r_Title;
        private readonly IExecutable r_Executable;
        internal List<MenuItem> SubItems { get; }

        public MenuItem(string i_Title, IExecutable i_Executable = null)
        {
            r_Title = i_Title;
            r_Executable = i_Executable;
            
            if (i_Executable == null)
            {
                SubItems = new List<MenuItem>();
            }
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (r_Executable != null)
            {
                throw new ArgumentException("Cannot add sub-items to an executable item.");
            }

            if (SubItems != null)
            {
                if (SubItems.Count == 0)
                {
                    SubItems.Add(new MenuItem("Back"));
                }

                SubItems.Add(i_MenuItem);
            }
            else
            {
                throw new ArgumentException("Cannot add sub-items to uninitialized list!");
            }
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            if (SubItems == null)
            {
                throw new ArgumentException("Cannot remove from an executable item.");
            }

            if (SubItems.Count == 0)
            {
                throw new ArgumentException("No items to remove in the SubItems list.");
            }

            if (!SubItems.Contains(i_MenuItem))
            {
                throw new ArgumentException("Menu item to remove does not exist in SubItems.");
            }

            SubItems.Remove(i_MenuItem);
        }

        public void Show()
        {
            if (r_Executable is IExecutable executableItem)
            {
                executableItem.Execute();
            }
            else if (SubItems.Count != 0)
            {
                int userChoice;
                bool needToPrintExit = SubItems[0].r_Title == "Exit";

                do
                {    
                    printMenuSubItems();

                    userChoice = getValidMenuOption(SubItems.Count - 1, needToPrintExit);

                    if (userChoice != 0)
                    {
                        SubItems[userChoice].Show();
                    }
                } while (userChoice != 0);
            }
            else
            {
                throw new ArgumentException("No sub-items available to show.");
            }
        }

        private void printMenuSubItems()
        {
            Console.Clear();
            Console.WriteLine($"===== {r_Title} =====");

            for (int i = 1; i < SubItems.Count; i++)
            {
                Console.WriteLine($"{i}. {SubItems[i].r_Title}");
            }

            Console.WriteLine($"0. {SubItems[0].r_Title}");
        }

        private static int getValidMenuOption(int i_MaximumChoice, bool i_IsExit)
        {
            bool isValid = false;
            int numericChoice;

            do
            {
                string returnText = i_IsExit ? "exit" : "back";
                
                Console.Write($"Please enter your choice (1-{i_MaximumChoice} or 0 to {returnText}): ");

                string userChoice = Console.ReadLine();

                if (!int.TryParse(userChoice, out numericChoice))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid integer.");
                }
                else
                {
                    isValid = numericChoice >= 0 && numericChoice <= (i_MaximumChoice);

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