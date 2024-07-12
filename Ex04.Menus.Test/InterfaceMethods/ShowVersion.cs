using System;
using System.Threading;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.InterfaceMethods
{
    public class ShowVersion : IExecutable
    {
        public void Execute()
        {
            Console.WriteLine("Version: 24.2.4.9504");
            Thread.Sleep(3000);
        }
    }
}