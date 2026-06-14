using System;
using Asta.Core.Application;
using Asta.Rendering.SilkWindow;


class Program
{

    static void Main()
    {
        Application app = new Application(new SilkWindow());
        app.run();
    }
}
