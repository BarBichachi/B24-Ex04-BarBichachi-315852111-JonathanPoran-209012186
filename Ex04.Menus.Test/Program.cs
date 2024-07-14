namespace Ex04.Menus.Test;

public class Program
{
    public static void Main()
    {
        InterfacesApplication interfaceApplication = new InterfacesApplication();

        interfaceApplication.Start();
        EventsApplication.Start();
    }
}