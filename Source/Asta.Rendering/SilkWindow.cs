using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;


namespace Asta.Rendering.SilkWindow;

public class SilkWindow : iWindow
{
    private static IWindow _window = default!;
    private Renderer _renderer = new Renderer();

    public bool IsRunning { get; set;}  = false;
    
    public void create()
    {
        Logger.Log("Creating window...");

        var options = WindowOptions.Default;
        options.Size = new Vector2D<int>(800, 600);
        options.Title = "Asta";
        options.API = new GraphicsAPI(ContextAPI.OpenGL, ContextProfile.Core, ContextFlags.Default, new APIVersion(3, 3));

        _window = Window.Create(options);

        Logger.Log("Window created successfully");
    }


    public void run()
    {

        _window.Load += OnLoad;
        _window.Render += OnRender;
        _window.Update += OnUpdate;
        _window.Closing += OnClosing;

    }

    public void Run_window()
    {
        IsRunning = true;
        
        _window.Run();
    }

    public void OnLoad()
    {

        IInputContext input = _window.CreateInput();
        foreach (var keyboard in input.Keyboards)
        {
            keyboard.KeyDown += OnKeyDown;
        }

        //_renderer.load(_window);
    
    }

    public void OnRender(double deltaTime)
    {
        
        //_renderer.render();

    }

    public void OnUpdate(double deltaTime)
    {
        // Update logic here
    }

    private void OnKeyDown(IKeyboard keyboard, Key key, int keyCode)
    {
        if (key == Key.Escape)
        {
            _window.Close();
        }
    }

    public void OnClosing()
    {
        Logger.Log("Closing window...");

        //_renderer.dispose();
    }
}