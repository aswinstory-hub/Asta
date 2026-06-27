using Asta.Core.InputKeys;
using System.Numerics;

namespace Asta.Core;

public static class Input
{
    private static IInput _implementation = default!;

    // Initialized once by the Runtime bootstrapper
    public static void Initialize(IInput implementation)
    {
        _implementation = implementation;
    }

    public static bool IsKeyPressed(AstaKey key) => _implementation.IsKeyPressed(key);
    public static bool IsMouseButtonPressed(AstaMouseButton button) => _implementation.IsMouseButtonPressed(button);
    public static Vector2 MousePosition => _implementation.GetMousePosition();
}
