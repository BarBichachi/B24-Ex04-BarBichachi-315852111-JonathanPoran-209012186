using System;
using System.Threading;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.InterfaceMethods
{
    public class ShowTime : IExecutable
    {
        public void Execute()
        {
            Console.WriteLine($"The hour is {DateTime.Now.ToString("HH:mm:ss")}");
            Thread.Sleep(3000);
        }
    }
}