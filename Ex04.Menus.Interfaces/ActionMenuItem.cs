using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal class ActionMenuItem : MenuItem
    {
        private readonly IExecutable r_Executable;

        public ActionMenuItem(string i_Title, IExecutable i_Executable) : base(i_Title)
        {
            this.r_Executable = i_Executable;
        }

        public override void Show()
        {
            r_Executable.Execute();
        }
    }
}
