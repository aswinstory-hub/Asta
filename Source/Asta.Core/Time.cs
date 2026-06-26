using System.Diagnostics;
using System.Threading;

public static class Time 
{
    private static double _lastTime;
    private static Stopwatch _timer = default!;

    public static double CurrentTime { get; private set; }
    public static double DeltaTime { get; private set; }
    public static double InstantFps { get; private set; }
    public static double AverageFps { get; private set; }
    
    private static double _fpsTimer = 0;
    private static int _frameCount = 0;
    
    private const double TARGET_FPS = 120.0;
    private const double TARGET_FRAME_TIME = 1.0 / TARGET_FPS;

    public static void Initialize()
    {
        Logger.Log("Initialize Time");
        _timer = new Stopwatch();   
        _timer.Start(); 
        _lastTime = _timer.Elapsed.TotalSeconds;
    }

    public static void Update()
    {
        CurrentTime = _timer.Elapsed.TotalSeconds;
        DeltaTime = CurrentTime - _lastTime;
        _lastTime = CurrentTime;

        // Safety fix: Prevent division by zero if delta time is impossibly small
        InstantFps = DeltaTime > 0.00001 ? 1.0 / DeltaTime : TARGET_FPS;

        _frameCount++;
        _fpsTimer += DeltaTime;

        if (_fpsTimer >= 0.5) 
        {
            AverageFps = _frameCount / _fpsTimer;
            _frameCount = 0;
            _fpsTimer = 0;
        }
    }

    public static void CapFrameRate()
    {
        double currentTimestamp = _timer.Elapsed.TotalSeconds;
        double frameExecutionTime = currentTimestamp - _lastTime;
        
        if (frameExecutionTime < TARGET_FRAME_TIME)
        {
            double timeToWait = TARGET_FRAME_TIME - frameExecutionTime;
            
            // 1. Heavy Sleep: Only sleep if we have more than 5ms remaining.
            // This avoids the Windows 15.6ms scheduling trap for tight windows.
            if (timeToWait > 0.005)
            {
                int msToWait = (int)(timeToWait * 1000.0) - 2; // Under-sleep intentionally
                if (msToWait > 0) Thread.Sleep(msToWait);
            }

            // 2. Precision Spin-Wait: Burn the last tiny microsecond fractions 
            // using pure CPU cycles until our target time is perfectly matched.
            while (_timer.Elapsed.TotalSeconds - _lastTime < TARGET_FRAME_TIME)
            {
                Thread.SpinWait(1); // Tells the CPU to wait efficiently without sleeping
            }
        }
    }

}
