using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Asta.Core.Application;

namespace Asta.Rendering.SilkWindow;

public class SilkWindow : iWindow
{
    private IWindow window = default!;

    public void run()
    {
        var options = WindowOptions.Default;
        options.Size = new Vector2D<int>(800, 600);
        options.Title = "Asta Engine";
        window = Window.Create(options);

        window.Load += OnLoad;
        window.Render += OnRender;
        window.Update += OnUpdate;

        window.Run();
    }

    private void OnLoad()
    {
        // Initialization code here
    }

    private void OnRender(double deltaTime)
    {
        // Rendering code here
    }

    private void OnUpdate(double deltaTime)
    {
        // Update logic here
    }
}