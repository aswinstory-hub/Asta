

public interface iWindow
{   

    public bool IsRunning { get; set;}

    void run();

    void Run_window();

    void create();

    void OnLoad();

    void OnRender(double deltaTime);

    void OnUpdate(double deltaTime);

    void OnClosing();

}