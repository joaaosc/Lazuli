using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Lazuli.Windows
{
    partial class Widgets
    { // create menu bar
        public StatusBar AddStatusBar()
        {
            var statusBar = new StatusBar(new StatusItem[] {
                new StatusItem(Key.Null,"There's nothing like Lapis-Lazuli...",null)
            });

            return statusBar;
        }
    }
}
