using System;

namespace Asta.Core.Application;

public class Application
{
    private iWindow _window = default!; 
    public string windowName = "Asta";

    public Application(iWindow window)
    {
        Logger.Log("Application has been created");

        _window = window;

        Logger.Log("Create Window");
        _window.SetWindow(windowName, 1280, 720);
    }


    public void run()
    {
        init();

        Logger.Log("Entering main loop...");

        while (_window.IsOpen)
        {
            _window.ProcessEvents();
    
        }

        Logger.Log("Shutting down window");
        _window.Shutdown();
        
    }

    private void init()
    {
        Logger.Log("Initializing application...");
        
        _window.Initialize();
    }

}

