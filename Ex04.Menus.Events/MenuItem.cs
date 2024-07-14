using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        protected readonly string r_Title;
        private List<MenuItem> m_SubItems;
        internal List<MenuItem> SubItems
        {
            get
            {
                return m_SubItems;
            }
        }
        public event Action m_Listeners;

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (m_Listeners == null)
            {
                if (m_SubItems == null)
                {
                    m_SubItems = new List<MenuItem>();
                }

                m_SubItems.Add(i_MenuItem);
            }
            else
            {
                throw new ArgumentException("Cannot add sub-items to an executable item.");
            }
        }

        internal void OnChosen()
        {
            bool isFinished = false;

            do
            {
                if (m_Listeners != null)
                {
                    m_Listeners.Invoke();
                    isFinished = true;
                }
                else
                {
                    int userChoice = GetValidOption(m_SubItems, "Back");

                    if (userChoice != 0)
                    {
                        m_SubItems[userChoice - 1].OnChosen();
                    }
                    else
                    {
                        isFinished = true;
                    }
                }
            } while (!isFinished);
        }

        internal int GetValidOption(List<MenuItem> i_SubItems, string returnString)
        {
            printSubItems(m_SubItems, returnString);

            bool isValid = false;
            int numericChoice;
            int numberOfSubItems = i_SubItems.Count;

            do
            {
                Console.Write($"Please enter your choice (1-{numberOfSubItems} or 0 to {returnString.ToLower()}): ");

                string userChoice = Console.ReadLine();

                if (!int.TryParse(userChoice, out numericChoice))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid integer.");
                }
                else
                {
                    isValid = numericChoice >= 0 && numericChoice <= numberOfSubItems;

                    if (!isValid)
                    {
                        Console.WriteLine($"You can only choose between 0 and {numberOfSubItems}. Try again.");
                    }
                }
            } while (!isValid);

            return numericChoice;
        }

        private void printSubItems(List<MenuItem> i_SubItems, string returnString)
        {
            int numOption = 1;

            Console.Clear();
            Console.WriteLine($"===== {r_Title} =====");

            foreach (MenuItem menuItem in i_SubItems)
            {
                Console.WriteLine($"{numOption}. {menuItem.r_Title}");
                numOption++;
            }

            Console.WriteLine($"0. {returnString}");
        }
    }
}