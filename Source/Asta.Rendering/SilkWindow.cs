using System.Drawing;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using Asta.Core.Application;

namespace Asta.Rendering.SilkWindow;

public class SilkWindow : iWindow
{
    private static IWindow _window = default!;
    private Renderer _renderer = new Renderer();
    

    public void run()
    {
        var options = WindowOptions.Default;
        options.Size = new Vector2D<int>(800, 600);
        options.Title = "Asta";
        options.API = new GraphicsAPI(ContextAPI.OpenGL, ContextProfile.Core, ContextFlags.Default, new APIVersion(3, 3));

        _window = Window.Create(options);

        _window.Load += OnLoad;
        _window.Render += OnRender;
        _window.Update += OnUpdate;
        _window.Closing += OnClosing;

        _window.Run();
    }

    private void OnLoad()
    {

        IInputContext input = _window.CreateInput();
        foreach (var keyboard in input.Keyboards)
        {
            keyboard.KeyDown += OnKeyDown;
        }

        _renderer.load(_window);
    
    }

    private void OnRender(double deltaTime)
    {
        
        _renderer.render();

    }

    private void OnUpdate(double deltaTime)
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

    private void OnClosing()
    {
        _renderer.dispose();
    }
}