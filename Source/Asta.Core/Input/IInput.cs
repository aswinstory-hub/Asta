using Asta.Core.InputKeys;
using System.Numerics;

namespace Asta.Core;

public interface IInput
{
    public bool IsKeyPressed(AstaKey key);
    public bool IsMouseButtonPressed(AstaMouseButton button);
    public Vector2 GetMousePosition();
}
