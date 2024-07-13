using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ActionMenuItem : MenuItem
    {
        private readonly IExecutable r_Executable;


        public ActionMenuItem(string i_Title, IExecutable i_Executable) : base(i_Title)
        {
            r_Executable = i_Executable;
        }

        public override void Show()
        {
            NotifyObservers();
            r_Executable.Execute();
        }
    }
}
