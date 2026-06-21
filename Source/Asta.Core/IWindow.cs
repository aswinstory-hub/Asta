

public interface iWindow
{   
    void run();

    void create();

    void OnLoad();

    void OnRender(double deltaTime);

    void OnUpdate(double deltaTime);

    void OnClosing();

}