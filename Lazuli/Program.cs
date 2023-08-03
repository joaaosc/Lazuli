using Lazuli.Windows;
using Terminal.Gui;

namespace Lazuli;

class Program
{
    static void Main()
    {
        // apenas testando pra ver se o git funciona
        Application.Init();
        Application.Run<FirstTimeWindow>();
        Application.Shutdown();
    }
}
