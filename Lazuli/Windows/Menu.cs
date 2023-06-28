using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Lazuli.Windows;


public class Home : Window
{
    public Home()
    {

        string Title = "Example App (Ctrl+Q to quit)";

        MenuBar menu = new MenuBar(new MenuBarItem[]
        {

            new MenuBarItem("Start", new MenuItem[]
            {
                new MenuItem("_Quit", "", () => Application.RequestStop())
            }),

            new MenuBarItem("Computational Physics", new MenuItem[]
                { new MenuItem("Simple Physics", "", () => Application.Run<Physics>())
                }),

            new MenuBarItem("Fluid Dynamics", new MenuItem[]
                { }),
        });

        // nest a window for the editor
        var win = new Window()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        View editor = new View()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };
        editor.ColorScheme = Colors.Dialog;


        // ADD THE VIEWS TO THE WINDOW
        Add(win,editor, menu);

    }

    

}




