namespace Asta.Core.Application;

public class Application
{
    private iWindow _window = default!; 
    public string windowName = "Asta";
    private bool _isRunning = false;


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

        _isRunning = true;

        while (_window.IsOpen && _isRunning)
        {
            _window.ProcessEvents();

            Time.Update();

            HandleInput();

            // Console.WriteLine($"Current Time: {Time.CurrentTime:F2}s, Delta Time: {Time.DeltaTime:F4}s, Instant FPS: {Time.InstantFps:F2}, Average FPS: {Time.AverageFps:F2}");


            //_window.PrepareRenderFrame();
            //_window.SwapBuffers();
            Time.CapFrameRate();
        }

        Shutdown();

    }

    private void init()
    {
        Logger.Log("Initializing application...");
        
        _window.Initialize();

        Time.Initialize();
    }

    public void HandleInput()
    {
        if (Input.IsKeyPressed(InputKeys.AstaKey.Escape))
        {
            _isRunning = false;
        }

        if (Input.IsKeyPressed(InputKeys.AstaKey.Space))
        {
            Console.WriteLine("Space bar pressed");
        }

    }

    private void Shutdown()
    {
        Logger.Log("Shutting down application...");

        _window.Shutdown();

        Logger.Log("Application has been shut down.");
    }

}

