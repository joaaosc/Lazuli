using Lazuli.Windows;
using Terminal.Gui;

namespace Lazuli;

class Program
{
    static void Main()
    {

        Application.Init();
        Application.Run<FirstTimeWindow>();
        Application.Shutdown();
    }
}
