using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Lazuli.Windows;


public class Demo
{
    static void Edit(string filename)
    {
        var top = new Toplevel()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };
        var menu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_Close", "", () => {
                    Application.RequestStop ();
                })
            }),
        });

        // nest a window for the editor
        var win = new Window(filename)
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1
        };

        var editor = new TextView()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };
        editor.Text = System.IO.File.ReadAllText(filename);
        win.Add(editor);

        // Add both menu and win in a single call
        top.Add(win, menu);
        Application.Run(top);
        Application.Shutdown();
    }
}