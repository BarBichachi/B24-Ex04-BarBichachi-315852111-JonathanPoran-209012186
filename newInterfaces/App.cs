
using System.Threading;

public class App
{
    public static void Main()
    {
        MainMenu mainMenu = new MainMenu("MainMenu");

        MenuItem subMenu1 = new MenuItem("sub menu 1");
        MenuItem MainSubItem1 = new MenuItem("Main SubItem 1");
        MenuItem MainSubItem2 = new MenuItem("Main SubItem 2");

        MenuItem subMenu11fsubMenu1  = new MenuItem("item 11");
        MenuItem subMenu22fsubMenu1  = new MenuItem("item 22");

        mainMenu.AddMenuItem(subMenu1);
        mainMenu.AddMenuItem(MainSubItem1);
        mainMenu.AddMenuItem(MainSubItem2);

        subMenu22fsubMenu1.m_MethodsNotifiers += foo;

        subMenu1.AddMenuItem(subMenu11fsubMenu1);
        subMenu1.AddMenuItem(subMenu22fsubMenu1);

        mainMenu.Show();
        Thread.Sleep(3000);

    }

    private static void foo()
    {
        Console.WriteLine("in foo");
        Thread.Sleep(3000);
    }
}