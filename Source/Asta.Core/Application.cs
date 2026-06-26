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

            Time.Update();

            Console.WriteLine($"Current Time: {Time.CurrentTime:F2}s, Delta Time: {Time.DeltaTime:F4}s, Instant FPS: {Time.InstantFps:F2}, Average FPS: {Time.AverageFps:F2}");
        
            Time.CapFrameRate();
        }

        Logger.Log("Shutting down window");
        _window.Shutdown();
        
    }

    private void init()
    {
        Logger.Log("Initializing application...");
        
        _window.Initialize();

        Time.Initialize();
    }

}

