using System;

namespace Ex04.Menus.Test
{
    internal class TestApplication
    {
        internal static void RunApplication()
        {
            bool exit = false;

            while (!exit)
            {
                PrintMainMenu();

                Console.Write("Enter your choice (1, 2, or 3): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StartInterfacesApplication();
                        break;
                    case "2":
                        StartEventsApplication();
                        break;
                    case "3":
                        Console.WriteLine("Exiting program...");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        break;
                }

                Console.WriteLine();  // Provide some space before showing the menu again
            }
        }

        private static void PrintMainMenu()
        {
            Console.WriteLine("===== Test application menu =====");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Interface App");
            Console.WriteLine("2. Events App");
            Console.WriteLine("3. Terminate Program");
        }

        private static void StartInterfacesApplication()
        {
            InterfacesApplication interfaceApplication = new InterfacesApplication();
            interfaceApplication.Start();
        }

        private static void StartEventsApplication()
        {
            EventsApplication eventsApplication = new EventsApplication();
            eventsApplication.Start();
        }
    }
}
