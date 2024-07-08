﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class InterfacesApplication
    {
        private MainMenu m_MainMenu = new MainMenu("Interface Menu");

        public void Start()
        {
            MenuItem versionAndCapitalsMenu = new MenuItem("Version and Capitals");
            MenuItem showVersionItem = new MenuItem("Show Version", new ShowVersion());
            MenuItem countCapitalsItem = new MenuItem("Count Capitals", new CountCapitals());

            versionAndCapitalsMenu.AddMenuItem(showVersionItem);
            versionAndCapitalsMenu.AddMenuItem(countCapitalsItem);

            MenuItem showDateAndTimeMenu = new MenuItem("Show Date/Time");
            MenuItem showTimeItem = new MenuItem("Show Time", new ShowTime());
            MenuItem showDateItem = new MenuItem("Show Date", new ShowDate());

            showDateAndTimeMenu.AddMenuItem(showTimeItem);
            showDateAndTimeMenu.AddMenuItem(showDateItem);

            m_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            m_MainMenu.AddMenuItem(showDateAndTimeMenu);
            m_MainMenu.Show();
        }
    }
    public class ShowVersion : IExecutable
    {
        public void Execute()
        {
            Console.WriteLine("Version");
            Thread.Sleep(3000);
        }
    }
    public class CountCapitals : IExecutable
    {
        public void Execute()
        {
            Console.WriteLine("Count Capitals");
            Thread.Sleep(3000);
        }
    }

    public class ShowTime : IExecutable
    {
        public void Execute()
        {
            Console.WriteLine("Time");
            Thread.Sleep(3000);
        }
    }

    public class ShowDate : IExecutable
    {
        public void Execute()
        {
            Console.WriteLine("Date");
            Thread.Sleep(3000);
        }
    }
}
