using System;

namespace Asta.Core.Application;

public interface iWindow
{   
    void run();
}


public class Application
{

    private readonly iWindow _window;

    public Application(iWindow window)
    {
        _window = window;
    }


    public void run()
    {
        _window.run();
    }

}

