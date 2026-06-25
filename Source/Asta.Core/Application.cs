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

        Logger.Log("Start Window...");
        _window.run();
        _window.Run_window();

        Logger.Log("Entering main loop...");
        if (_window.IsRunning)
        {
            Console.WriteLine("Running...");
        }

    }

    private void init()
    {
        Logger.Log("Initializing application...");
        _window.create();
        
    }

}

