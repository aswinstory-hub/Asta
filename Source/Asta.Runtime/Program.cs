using System;
using Asta.Core;
using Asta.Core.Application;
using Asta.Rendering.SilkWindow;


class Program
{

    static void Main()
    {
        Logger.Log("Asta Summoned!"); 

        Logger.Log("Create Engine Window");
        SilkWindow engineWindow = new SilkWindow();


        Logger.Log("Create Application");
        Application app = new Application(engineWindow);

        Logger.Log("Connect to input system");
        Input.Initialize(engineWindow);

        app.run();
    }
}
