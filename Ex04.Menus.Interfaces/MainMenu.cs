﻿using System;
using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly MenuItem r_MainMenu;
        public string EndMessage { get; set; }

        public MainMenu(string i_Title)
        {
            r_MainMenu = new MenuItem(i_Title);
            EndMessage = "You chose to exit, see you next time!";
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MainMenu.AddMenuItem(i_MenuItem);
        }

        public void Show()
        {
            Console.Clear();
            r_MainMenu.onChosen();
            Console.WriteLine(EndMessage);
            Thread.Sleep(3000);
        }
    }
}