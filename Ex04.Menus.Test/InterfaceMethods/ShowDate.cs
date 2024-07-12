using System;
using System.Threading;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.InterfaceMethods
{
    public class ShowDate : IExecutable
    {
        public void Execute()
        {
            Console.WriteLine($"The date is {DateTime.Now:dd/MM/yyyy}");
            Thread.Sleep(3000);
        }
    }
}