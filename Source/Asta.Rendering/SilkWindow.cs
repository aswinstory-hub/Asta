using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;


namespace Asta.Rendering.SilkWindow;

public class SilkWindow : iWindow
    {
        // Internal Silk.NET window reference
        private IWindow _nativeWindow = default!;

        // Exposed property for your loop condition: while(Window.IsOpen)
        public bool IsOpen => !_nativeWindow.IsClosing;

        // Exposes the underlying Silk.NET window if your Renderer/Input subsystems need to query it directly
        public IWindow NativeWindow => _nativeWindow;

        public void SetWindow(string title, int width, int height)
        {
            // 1. Configure the window options
            var options = WindowOptions.Default;
            options.Size = new Vector2D<int>(width, height);
            options.Title = title;
            options.API = GraphicsAPI.Default; // Automatically sets up OpenGL, Vulkan, etc.

            // 2. Create the window instance (Does NOT open or display it yet)
            _nativeWindow = Window.Create(options);
        }

        public void Initialize()
        {
            // 3. Bootstraps OS hooks, creates the native handle and graphics context.
            // Control returns immediately back to your application setup.
            _nativeWindow.Initialize();
        }

        public void ProcessEvents()
        {
            // 4. Polls the OS for window resizing, moving, closing, and hardware peripheral input events.
            _nativeWindow.DoEvents();
        }

        public void PrepareRenderFrame()
        {
            // 5. Signals the window to prepare its active graphics context for drawing.
            _nativeWindow.DoRender();
        }

        public void SwapBuffers()
        {
            // 6. Flips the back-buffer to the screen. 
            // In Silk.NET, this is handled through the active graphics context.
            _nativeWindow.GLContext?.SwapBuffers();
        }

        public void Shutdown()
        {
            // 7. Frees the native window handle and unbinds graphics contexts from memory.
            _nativeWindow.Dispose();
        }
    }