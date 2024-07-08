namespace Ex04.Menus.Interfaces
{
    public interface IMenu
    {
        void AddMenuItem(MenuItem i_MenuItem);
        void RemoveMenuItem(MenuItem i_MenuItem);
        void Show();
    }
}