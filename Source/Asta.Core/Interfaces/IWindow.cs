

public interface iWindow
{   

    public bool IsOpen { get; }

    //public iWindow NativeWindow { get; set;}

    public void SetWindow(string title, int width, int height);

    public void Initialize();

    public void ProcessEvents();

    public void PrepareRenderFrame();

    public void SwapBuffers();

    public void Shutdown();

    public void Render();
}