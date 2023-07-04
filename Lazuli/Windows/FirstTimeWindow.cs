using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Lazuli.Windows;


public class FirstTimeWindow : Window
{
    private Encryption encrypter = new Encryption();
    public FirstTimeWindow()
    {
        MessageBox.Query("Welcome!", "This is a simple journal app which runs on a terminal UI;\n\n " +
                                     "It encrypt all your entries! You will need to choose a password on the next screen.\n\n"+
                                     "You can only read your entries with the chosen password, and there's no way around.\n\n" +
                                     "WARNING: YOU CAN ONLY SET YOUR PASSWORD ONCE!!", "Ok");

        Toplevel toplevel = new Toplevel()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };
        toplevel.ColorScheme = Colors.TopLevel;

        // nest a window for the editor
        var win = new Window("Choose your password. It will be also encrypted.")
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill() 
        };
        win.ColorScheme = Colors.TopLevel;

        Label passwordLabel = new Label("Choose your password")
        {
            X = Pos.Center(),
            Y = Pos.Center() - 2,
            Width = 13,
            Height = 1
        };
        passwordLabel.ColorScheme = Colors.TopLevel;

        TextField passwordField = new TextField("")
        {
            X = Pos.Center(),
            Y = Pos.Bottom(passwordLabel),
            Width = 13,
            Height = 1
        };
        passwordField.ColorScheme = Colors.TopLevel;

        Label passwordLabel2 = new Label("(it must have at maximum 10 characters)")
        {
            X = Pos.Center(),
            Y = Pos.Bottom(passwordField),
            Width = 13,
            Height = 1
        };
        passwordLabel2.ColorScheme = Colors.TopLevel;

        passwordField.KeyPress += (args) =>
        {
            if (args.KeyEvent.Key == Key.Enter)
            {
                if (passwordField.Text.ToString().Length > 10)
                    MessageBox.Query("Error", "Your password can't have more than 10 characters", "Ok");
                else
                {
                    encrypter.hash = encrypter.GenerateHash(passwordField.Text.ToString());
                    MessageBox.Query("Success!", "Your password have been set and hashed.", "Go to home");
                    Application.Run<Home>();
                }
            }

        };

        Add(toplevel,win, passwordLabel, passwordField, passwordLabel2);





        // ADD THE VIEWS TO THE WINDOW
        // Application.Top.Add(toplevel,win,menu);

    }



}




