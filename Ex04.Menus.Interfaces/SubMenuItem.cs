using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class SubMenuItem : MenuItem
    {
        public SubMenuItem(string i_Title) : base(i_Title)
        {
        }

        public void AddActionMenuItem(string i_Title, IExecutable i_Executable)
        {
            var actionMenuItem = new ActionMenuItem(i_Title, i_Executable);
            AddSubMenuItem(actionMenuItem);
        }

        public void AddSubMenuItem(MenuItem i_MenuItem)
        {
            SubItems.Add(i_MenuItem);
        }

        public void RemoveSubMenuItem(MenuItem i_MenuItem)
        {
            SubItems.Remove(i_MenuItem);
        }

        public override void Show()
        {
            int userChoice;
            do
            {
                PrintMenu();

                userChoice = GetValidMenuOption(SubItems.Count);

                if (userChoice != 0)
                {
                    SubItems[userChoice - 1].Show();
                }
            } while (userChoice != 0);
        }

        private void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine($"===== {Title} =====");

            for (int i = 0; i < SubItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {SubItems[i].Title}");
            }

            Console.WriteLine($"0. Back");
        }

        private int GetValidMenuOption(int i_MaximumChoice)
        {
            int numericChoice;
            bool isValid = false;

            do
            {
                Console.Write($"Please enter your choice (0-{i_MaximumChoice}): ");

                string userChoice = Console.ReadLine();

                isValid = int.TryParse(userChoice, out numericChoice) && (numericChoice >= 0 && numericChoice <= i_MaximumChoice);
                if (!isValid)
                {
                    Console.WriteLine($"Invalid choice. Please enter a valid integer between 0 and {i_MaximumChoice}.");
                }
            } while (!isValid);

            return numericChoice;
        }
    }
}
