using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public interface IMenuObserver
    {
        void MenuItemSelected(MenuItem i_MenuItem);
    }
}
