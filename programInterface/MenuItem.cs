namespace programInterface
{
    public class MenuItem : IMenuListener
    {
        protected readonly string r_Title = string.Empty;
        private List<MenuItem> m_SubItems = new List<MenuItem>();
        private bool? m_IsSubMenu;
        private IMenuListener m_MenuListener;
        private List<IMethodsListener> m_MethodListener;

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            SetIsSubMenu(true);

            if (m_IsSubMenu == true)
            {
                m_SubItems.Add(i_MenuItem);
                i_MenuItem.m_MenuListener = this;
            }
            else
            {
                throw new ArgumentException("Cannot add sub-items to an executable item.");
            }
        }

        internal void Show()
        {
            if(m_IsSubMenu == null || m_IsSubMenu == false)
            {
                m_MethodListener();
            }
            else if(m_IsSubMenu != null)
            {
                int userChoice;

                Console.Clear();
                Console.WriteLine($"===== {r_Title} =====");

                printSubItems(m_SubItems);

                string returnString = m_MenuNotifier == null ? "Exit" : "Back";

                Console.WriteLine($"0. {returnString}");

                userChoice = getValidOption(m_SubItems, returnString);

                if (userChoice != 0)
                {
                    m_SubItems[userChoice - 1].Show();
                }
            }
            m_MenuNotifier?.Invoke();
        }

        private int getValidOption(List<MenuItem> i_SubItems, string i_ReturnString)
        {
            bool isValid = false;
            int numericChoice;
            int numberOfSubItems = i_SubItems.Count;
            do
            {
                Console.Write($"Please enter your choice (1-{numberOfSubItems} or 0 to {i_ReturnString}): ");

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

            foreach (MenuItem menuItem in i_SubItems)
            {
                Console.WriteLine($"{numOption}. {menuItem}");
                numOption++;
            }
        }

        private void SetIsSubMenu(bool value)
        {
            if (m_IsSubMenu == null)
            {
                m_IsSubMenu = value;
            }
        }

        public override string ToString()
        {
            return r_Title;
        }

        void IMenuListener.MenuItemReport()
        {

        }
    }
}