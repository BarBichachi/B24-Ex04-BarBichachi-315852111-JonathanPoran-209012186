using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuListener
    {
        protected readonly string r_Title;
        private List<MenuItem> m_SubItems = new List<MenuItem>();
        private IMenuListener m_MenuListener;
        private readonly IMethodListener r_MethodListener;

        public MenuItem(string i_Title, IMethodListener i_Listener = null)
        {
            r_Title = i_Title;
            r_MethodListener = i_Listener;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (r_MethodListener == null)
            {
                m_SubItems.Add(i_MenuItem);

                if (i_MenuItem.m_MenuListener == null)
                {
                    i_MenuItem.m_MenuListener = this;
                }
                else
                {
                    throw new ArgumentException($"{i_MenuItem} is already in another menu.");
                }
            }
            else
            {
                throw new ArgumentException("Cannot add sub-items to an executable item.");
            }
        }

        internal void onChosen()
        {
            if (r_MethodListener != null)
            {
                r_MethodListener?.ChosenMethod(this.r_Title);
                m_MenuListener?.ReportFinished();
            }
            else
            {
                printSubItems(m_SubItems);

                int userChoice = getValidOption(m_SubItems);

                if (userChoice != 0)
                {
                    m_SubItems[userChoice - 1].onChosen();
                }
                else
                {
                    m_MenuListener?.ReportFinished();
                }
            }
        }

        private int getValidOption(List<MenuItem> i_SubItems)
        {
            bool isValid = false;
            int numericChoice;
            int numberOfSubItems = i_SubItems.Count;
            string returnString = m_MenuListener == null ? "exit" : "back";

            do
            {
                Console.Write($"Please enter your choice (1-{numberOfSubItems} or 0 to {returnString}): ");

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

        private void printSubItems(List<MenuItem> i_SubItems)
        {
            int numOption = 1;
            string returnString = m_MenuListener == null ? "Exit" : "Back";

            Console.Clear();
            Console.WriteLine($"===== {r_Title} =====");

            foreach (MenuItem menuItem in i_SubItems)
            {
                Console.WriteLine($"{numOption}. {menuItem.r_Title}");
                numOption++;
            }

            Console.WriteLine($"0. {returnString}");
        }

        void IMenuListener.ReportFinished()
        {
            this.onChosen();
        }
    }
}