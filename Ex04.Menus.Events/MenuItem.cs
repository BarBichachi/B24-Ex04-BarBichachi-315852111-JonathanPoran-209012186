using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        private readonly string r_Title;
        internal List<MenuItem> SubItems { get; }
        private Action Action { get; }
        
        public MenuItem(string i_Title, Action i_Action = null)
        {
            r_Title = i_Title;
            
            if (i_Action == null)
            {
                SubItems = new List<MenuItem>();
            }
            else
            {
                Action = i_Action;
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
                if (SubItems.Count != 0)
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
        }

        private void printMenuSubItems()
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