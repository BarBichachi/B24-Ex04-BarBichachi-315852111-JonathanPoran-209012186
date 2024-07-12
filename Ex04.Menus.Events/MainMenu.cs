﻿using System.Threading;
using System;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly MenuItem r_MainMenu;
        public string EndMessage { get; set; }
        
        public MainMenu(string i_Title)
        {
            EndMessage = "You chose to exit, see you next time!";
            r_MainMenu = new MenuItem(i_Title);
            
            r_MainMenu.SubItems.Add(new MenuItem("Exit"));
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MainMenu.AddMenuItem(i_MenuItem);
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            r_MainMenu.RemoveMenuItem(i_MenuItem);
        }

        public void Show()
        {
            r_MainMenu.Show();
            Console.Clear();
            Console.WriteLine(EndMessage);
            Thread.Sleep(3000);
        }
    }
}