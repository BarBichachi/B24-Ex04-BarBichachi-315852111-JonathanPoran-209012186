namespace programInterface;

internal interface IMenuListener
{
    void OneOfMySubitemFinish ();
}

public interface IMethodListener 
{
    void MenuItemChoosed (string i_MenuItemTitel);
}