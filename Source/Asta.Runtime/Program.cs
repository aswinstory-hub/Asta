using System;
using Asta.Core.Application;
using Asta.Rendering.SilkWindow;


class Program
{

    static void Main()
    {
        Logger.Log("Application started.");
        Application app = new Application(new SilkWindow());
        app.run();
    }
}
