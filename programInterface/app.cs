namespace programInterface;

public class App
{
    public static void Main() 
    {
        Stam s = new Stam();
        MainMenu mainMenu = new MainMenu("MainMenu");

        MenuItem subMenu1 = new MenuItem("sub menu 1");
        MenuItem MainItem1 = new MenuItem("Main Item 1");

        MenuItem subMenu11fsubMenu1  = new MenuItem("item 11");
        MenuItem subMenu22fsubMenu1  = new MenuItem("item 22");

        subMenu22fsubMenu1.MethodListener = s;
        subMenu11fsubMenu1.MethodListener = s;
        MainItem1.MethodListener = s;

        mainMenu.AddMenuItem(subMenu1);
        mainMenu.AddMenuItem(MainItem1);



        subMenu1.AddMenuItem(subMenu11fsubMenu1);
        subMenu1.AddMenuItem(subMenu22fsubMenu1);

        mainMenu.Show();
        Thread.Sleep(3000);

    }
}

public class Stam :IMethodListener
{
    public void MenuItemChoosed(string i_MenuItemTitel)
    {
        if(i_MenuItemTitel == "item 22")
        {
            foo();
        }
        else if(i_MenuItemTitel == "item 11")
        {
            goo();
        }
        else
        {
            woo();
        }

    }
    private static void foo()
    {
        Console.WriteLine("in foo");
        Thread.Sleep(3000);
    }

    private static void goo()
    {
        Console.WriteLine("in goo");
        Thread.Sleep(3000);
    }

    private static void woo()
    {
        Console.WriteLine("in woo");
        Thread.Sleep(3000);
    }
}