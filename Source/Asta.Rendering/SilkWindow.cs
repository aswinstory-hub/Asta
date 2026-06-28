using System.Numerics;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using Asta.Core;
using Asta.Core.InputKeys;



namespace Asta.Rendering.SilkWindow;

// SilkWindow fulfills both the window and input contracts cleanly
public class SilkWindow : iWindow, IInput
{
    private IWindow _nativeWindow = default!;
    private IInputContext _inputContext = default!;
    private IKeyboard _keyboard = default!;
    private IMouse _mouse = default!;

    private GL gl = default!; 


    private static uint _vao;
    private static uint _vbo;
    private static uint _shaderProgram;

    private static readonly float[] Vertices = 
    {
        -0.5f, -0.5f, 0.0f, // Bottom Left
         0.5f, -0.5f, 0.0f, // Bottom Right
         0.0f,  0.5f, 0.0f  // Top Center
    };

    private string VertexShaderSource = default!;
    private string FragmentShaderSource = default!;


    public bool IsOpen => !_nativeWindow.IsClosing;

    public void SetWindow(string title, int width, int height)
    {
        var options = WindowOptions.Default;
        options.Size = new Vector2D<int>(width, height);
        options.Title = title;
        //options.VSync = true;
        options.API = new GraphicsAPI(ContextAPI.OpenGL, ContextProfile.Core, ContextFlags.Default, new APIVersion(4, 5));

        _nativeWindow = Window.Create(options);
    }

    public void Initialize()
    {
        _nativeWindow.Initialize();
        
        // Spin up input wrappers right after window creation
        _inputContext = _nativeWindow.CreateInput();

        if (_inputContext.Keyboards.Count > 0)
        {
            _keyboard = _inputContext.Keyboards[0];
        }

        if (_inputContext.Mice.Count > 0)
        {
            _mouse = _inputContext.Mice[0];
        }

        gl = _nativeWindow.CreateOpenGL();

        gl.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
    }
    

    public void ProcessEvents() => _nativeWindow.DoEvents();
    public void ClearScreen() => gl.Clear((uint) ClearBufferMask.ColorBufferBit | (uint) ClearBufferMask.DepthBufferBit);
    public void PrepareRenderFrame() => _nativeWindow.DoRender();
    public void SwapBuffers() => _nativeWindow.GLContext?.SwapBuffers();
    
    public void Shutdown()
    {
        _inputContext?.Dispose();
        DisposeGL();
        _nativeWindow.Dispose();
    }

    // --- IInput Interface Implementation ---
    public bool IsKeyPressed(AstaKey key)
    {
        return _keyboard.IsKeyPressed(TranslateKey(key));
    }

    public bool IsMouseButtonPressed(AstaMouseButton button)
    {
        return _mouse.IsButtonPressed(TranslateMouseButton(button));
    }

    public Vector2 GetMousePosition()
    {
        return new Vector2(_mouse.Position.X, _mouse.Position.Y);
    }

    // Private conversion tables
    private Key TranslateKey(AstaKey key) => key switch
    {
        AstaKey.W => Key.W,
        AstaKey.A => Key.A,
        AstaKey.S => Key.S,
        AstaKey.D => Key.D,
        AstaKey.Space => Key.Space,
        AstaKey.Escape => Key.Escape,
        AstaKey.LeftShift => Key.ShiftLeft,
        _ => Key.Unknown
    };

    private MouseButton TranslateMouseButton(AstaMouseButton button) => button switch
    {
        AstaMouseButton.Left => MouseButton.Left,
        AstaMouseButton.Right => MouseButton.Right,
        AstaMouseButton.Middle => MouseButton.Middle,
        _ => MouseButton.Unknown
    };

    public void Render()
    {
        // Clear current Framebuffer pixels using pre-configured clearing attributes
        gl.Clear((uint)ClearBufferMask.ColorBufferBit);

        // Target the active pipeline shader program
        gl.UseProgram(_shaderProgram);

        // Re-bind geometric vertex structure schema layout state
        gl.BindVertexArray(_vao);

        // Execute draw command arrays sequentially downstream onto rendering pipeline targets
        gl.DrawArrays(PrimitiveType.Triangles, 0, 3);

    }

    public void LoadRender()
    {
        // Create and Compile Vertex Shader
        VertexShaderSource = Shader.LoadVertexShader();
        uint vertexShader = gl.CreateShader(ShaderType.VertexShader);
        gl.ShaderSource(vertexShader, VertexShaderSource);
        gl.CompileShader(vertexShader);
        CheckShaderCompileStatus(vertexShader);

        // Create and Compile Fragment Shader
        FragmentShaderSource = Shader.LoadFragmentShader();
        uint fragmentShader = gl.CreateShader(ShaderType.FragmentShader);
        gl.ShaderSource(fragmentShader, FragmentShaderSource);
        gl.CompileShader(fragmentShader);
        CheckShaderCompileStatus(fragmentShader);

        // Link shaders into a final executable Program Pipeline on the GPU
        _shaderProgram = gl.CreateProgram();
        gl.AttachShader(_shaderProgram, vertexShader);
        gl.AttachShader(_shaderProgram, fragmentShader);
        gl.LinkProgram(_shaderProgram);
        CheckProgramLinkStatus(_shaderProgram);

        // Clean up standalone shader units now that they are linked
        gl.DeleteShader(vertexShader);
        gl.DeleteShader(fragmentShader);

        // Generate and Bind VAO (Tracks memory layouts)
        _vao = gl.GenVertexArray();
        gl.BindVertexArray(_vao);

        // Generate and Bind VBO (Holds vertex raw data arrays)
        _vbo = gl.GenBuffer();
        gl.BindBuffer(BufferTargetARB.ArrayBuffer, _vbo);

        // Send local memory data to graphics card high-speed memory safely
        unsafe
        {
            fixed (void* v = Vertices)
            {
                gl.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(Vertices.Length * sizeof(float)), v, BufferUsageARB.StaticDraw);
            }

            // Define structural stride rules for shader attribute position mapping (Location 0)
            gl.VertexAttribPointer(0, 3, GLEnum.Float, false, 3 * sizeof(float), (void*)0);    
            gl.EnableVertexAttribArray(0);
        }

        // Unbind layout schemas to prevent accidental alterations
        gl.BindBuffer(BufferTargetARB.ArrayBuffer, 0);
        gl.BindVertexArray(0);

    }

    private void CheckShaderCompileStatus(uint shader)
    {
        gl.GetShader(shader, ShaderParameterName.CompileStatus, out int status);
        if (status == 0)
        {
            string infoLog = gl.GetShaderInfoLog(shader);
            throw new Exception($"GLSL Shader Compilation Failed: {infoLog}");
        }
    }

    private void CheckProgramLinkStatus(uint program)
    {
        gl.GetProgram(program, ProgramPropertyARB.LinkStatus, out int status);
        if (status == 0)
        {
            string infoLog = gl.GetProgramInfoLog(program);
            throw new Exception($"GLSL Program Link Failed: {infoLog}");
        }
    }

    private void DisposeGL()
    {
        // Safely deallocate native driver memory objects
        gl.DeleteBuffer(_vbo);
        gl.DeleteVertexArray(_vao);
        gl.DeleteProgram(_shaderProgram);
        gl.Dispose();
    }

}
