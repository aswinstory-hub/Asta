using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Asta.Core;
using Asta.Core.InputKeys;
using System.Numerics;

namespace Asta.Rendering.SilkWindow;

// SilkWindow fulfills both the window and input contracts cleanly
public class SilkWindow : iWindow, IInput
{
    private IWindow _nativeWindow = default!;
    private IInputContext _inputContext = default!;
    private IKeyboard _keyboard = default!;
    private IMouse _mouse = default!;

    public bool IsOpen => !_nativeWindow.IsClosing;

    public void SetWindow(string title, int width, int height)
    {
        var options = WindowOptions.Default;
        options.Size = new Vector2D<int>(width, height);
        options.Title = title;
        options.API = GraphicsAPI.Default; 

        _nativeWindow = Window.Create(options);
    }

    public void Initialize()
    {
        _nativeWindow.Initialize();
        
        // Spin up input wrappers right after window creation
        _inputContext = _nativeWindow.CreateInput();

        if (_inputContext.Keyboards.Count > 0)
        {
            _keyboard = _inputContext.Keyboards[0];
        }

        if (_inputContext.Mice.Count > 0)
        {
            _mouse = _inputContext.Mice[0];
        }
    }
    

    public void ProcessEvents() => _nativeWindow.DoEvents();
    public void PrepareRenderFrame() => _nativeWindow.DoRender();
    public void SwapBuffers() => _nativeWindow.GLContext?.SwapBuffers();
    
    public void Shutdown()
    {
        _inputContext?.Dispose();
        _nativeWindow.Dispose();
    }

    // --- IInput Interface Implementation ---
    public bool IsKeyPressed(AstaKey key)
    {
        return _keyboard.IsKeyPressed(TranslateKey(key));
    }

    public bool IsMouseButtonPressed(AstaMouseButton button)
    {
        return _mouse.IsButtonPressed(TranslateMouseButton(button));
    }

    public Vector2 GetMousePosition()
    {
        return new Vector2(_mouse.Position.X, _mouse.Position.Y);
    }

    // Private conversion tables
    private Key TranslateKey(AstaKey key) => key switch
    {
        AstaKey.W => Key.W,
        AstaKey.A => Key.A,
        AstaKey.S => Key.S,
        AstaKey.D => Key.D,
        AstaKey.Space => Key.Space,
        AstaKey.Escape => Key.Escape,
        AstaKey.LeftShift => Key.ShiftLeft,
        _ => Key.Unknown
    };

    private MouseButton TranslateMouseButton(AstaMouseButton button) => button switch
    {
        AstaMouseButton.Left => MouseButton.Left,
        AstaMouseButton.Right => MouseButton.Right,
        AstaMouseButton.Middle => MouseButton.Middle,
        _ => MouseButton.Unknown
    };
}
