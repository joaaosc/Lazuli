using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Lazuli.Windows;


public class Home : Window
{
    private Encryption encryptInfo = new Encryption();
    public Home()
    {
        

        Toplevel toplevel = new Toplevel()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        MenuBar menu = new MenuBar(new MenuBarItem[]
        {

            new MenuBarItem("▼", new MenuItem[]
            {
                new MenuItem("_Quit", "", () => Application.RequestStop())
            }),

            new MenuBarItem("Entries", new MenuItem[]
                { new MenuItem("View saved entries", "", () => Application.Run<Entries>())
                }),

            new MenuBarItem("Decrypt", new MenuItem[]
                { }),
        });

        // nest a window for the editor
        var win = new Window("Just start writing")
        {
            X = 0,
            Y = 1,
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
        
        Label titleLabel = new Label("Entry title:")
        {
            X = Pos.Bottom(editor) + 2,
            Y = 0,
            Width = 13,
            Height = 1
        };

        TextField titleField = new TextField("")
        {
            X = Pos.Right(titleLabel) + 1,
            Y = 0,
            Width = Dim.Fill(),
            Height = 1
        };

        titleField.KeyPress += (args) =>
        {
            if (args.KeyEvent.Key == Key.Enter)
            {
                string entryTitle = titleField.Text.ToString();
            }

        };

        Label separatorLabel = new Label("========================================================================================================================================================================================================================================")
        {
            X = 0,
            Y = 1,
            Width = 13,
            Height = 1
        };


        TextView writeField = new TextView()
        {
            X = 0,
            Y = Pos.Bottom(titleLabel) + 1,
            Width = Dim.Fill(),
            Height = Dim.Fill(1)
        };
        writeField.ColorScheme = Colors.TopLevel;

        Button encryptButton = new Button()
        {
            Text = "Encrypt",
            Y = Pos.Bottom(writeField),
            // center the login button horizontally
            X = Pos.Center(),
            IsDefault = true,
        };

        encryptButton.Clicked += () => {
            if (writeField.Text.ToString() == "" | titleField.Text.ToString() == "")
            {
                MessageBox.Query("Error", "You didn't wrote any messsage on your entry", "Ok");
            }
            else
            {
                encryptInfo.Encrypt(writeField.Text.ToString()!,titleField.Text.ToString()!);
                MessageBox.Query("Success", "Entry saved successfully (encrypted!)", "Ok");
                writeField.Text = string.Empty;
                titleField.Text = string.Empty;
            }

        };



        win.Add(titleLabel,separatorLabel,titleField,writeField,encryptButton);
        
        
        Add(toplevel,menu,win);


        // ADD THE VIEWS TO THE WINDOW
        // Application.Top.Add(toplevel,win,menu);

    }

    

}




