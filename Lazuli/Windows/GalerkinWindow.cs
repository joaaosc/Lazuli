using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using NStack;

namespace Lazuli.Windows;


public class Physics : Window
{
    public Physics()
    {


        MenuBar menu = new MenuBar(new MenuBarItem[]
        {

            new MenuBarItem("Home", new MenuItem[]
            {
                new MenuItem("Go", "", () => Application.Run<Home>())
            }),

        });


        View Window = new View("TBD")
        {
            X = 3,
            Y = 2,
            Width = Dim.Percent(50f),
            Height = Dim.Fill(),
        };

        Label NodeInputLabel = new Label("Insert: ")
        {
            X = 3,
            Y = 3,
            Width = 3,
            Height = 1

        };


        Button button = new Button()
        {
            Text = "Login",
            Y = Pos.Center(),
            // center the login button horizontally
            X = Pos.Center(),
            IsDefault = true,
        };

        button.Clicked += () => Application.Run<Home>();

        Add(menu,Window,NodeInputLabel,button);
    }
}


