using System;

namespace Asta.Core.Application;

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

