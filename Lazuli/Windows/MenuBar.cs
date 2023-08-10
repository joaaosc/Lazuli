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
        public MenuBar AddMenuBarWidget()
        {
            return new MenuBar(new MenuBarItem[] {
                new MenuBarItem("_Sobre", new MenuItem[] {
                    new MenuItem("_Sobre", "Exibe informações sobre o programa", () => ShowAboutDialog()),
                }),
                new MenuBarItem("_Entries", new MenuItem[] {
                    new MenuItem("_Entradas", "Exibe as entradas", () => ShowMessageBox("Entries", "Este é o menu Entries")),
                }),
                new MenuBarItem("_Write", new MenuItem[] {
                    new MenuItem("_Escrever", "Permite escrever algo", () => ShowMessageBox("Write", "Este é o menu Write")),
                }),
            });
        }

        static void ShowAboutDialog()
        {
            Dialog dialog = new Dialog("Sobre",50,10);
            Label label = new Label(1,1,
                "Feito por João Pedro de S. T. Costa, 2023.\n\nFeito com amor utilizando a biblioteca\nTerminal.GUI.");
            Button okButton = new Button(1,4, "OK");

            // do button action
            okButton.Clicked += () => dialog.Running = false;
            dialog.Add(label,okButton);
            Application.Run(dialog); //faz a aplicação rodar o dialog. Que será executado numa ação da menubar
        }
        static void ShowMessageBox(string title, string message)
        {
            Dialog dialog = new Dialog(title,50,50,new Button("OK"));
            Label label = new Label(0, 0, message);

            dialog.Add(label);
            Application.Run(dialog);
        }
        
    }
}
