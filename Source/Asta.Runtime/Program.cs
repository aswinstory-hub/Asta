using System;
using Asta.Core;
using Asta.Core.Application;
using Asta.Rendering.SilkWindow;


class Program
{

    static void Main()
    {
        Logger.Log("Asta arised!"); 

        Logger.Log("Create Engine Window");
        SilkWindow engineWindow = new SilkWindow();

        Logger.Log("Connect to input system");
        Input.Initialize(engineWindow);

        Application app = new Application(engineWindow);
        app.run();
    }
}
