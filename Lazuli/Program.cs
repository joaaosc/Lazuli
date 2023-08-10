using Spectre.Console;
using Terminal.Gui;
using Lazuli.Windows;

namespace Lazuli;

class Program
{
    static void Main()
    {

        Application.Init(); //initializes a new instance of terminal.gui app. Creates a TopLevel and assign to Top.

        Toplevel top = Application.Top; 
        Widgets widgets = new Widgets();
        
        //adding widgets
        top.Add(widgets.AddMenuBarWidget());
        top.Add(widgets.AddStatusBar());


        Application.Run();

    }
}
