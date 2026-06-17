using System.IO;

public class Shader
{
    private const string ShaderDir = "Assets/Shaders";

    public static string LoadVertexShader(string name = "Default")
    {
        return LoadShaderFile(Path.Combine(ShaderDir, $"{name}.vert"));
    }

    public static string LoadFragmentShader(string name = "Default")
    {
        return LoadShaderFile(Path.Combine(ShaderDir, $"{name}.frag"));
    }

    private static string LoadShaderFile(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"Shader file not found: {path}");

        return File.ReadAllText(path);
    }

    public static (string vertex, string fragment) LoadShaderPair(string name = "Default")
    {
        return (LoadVertexShader(name), LoadFragmentShader(name));
    }
}
