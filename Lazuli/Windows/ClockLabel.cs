using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Lazuli.Windows
{
    public class ClockLabel
    {

        public Label clocklLabel = new Label()
        {
            X = Pos.AnchorEnd(10),
            TextFormatter = Pos.AnchorEnd(0),
            Width = 10,
            Height = 1,

        };




    }
}
