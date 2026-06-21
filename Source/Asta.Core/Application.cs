using System;

namespace Asta.Core.Application;

public class Application
{
    public iWindow _window; 

    public Application(iWindow SilkWindow)
    {
        _window = SilkWindow;
    }


    public void run()
    {
        init();
    }

    private void init()
    {
        Logger.Log("Initializing application...");
        _window.create();
    }

}

