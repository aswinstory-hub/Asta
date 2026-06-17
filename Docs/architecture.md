# Asta - Project Architecture

## Overview
Asta is a C# graphics application using Silk.NET for window management and OpenGL rendering.

## Core Components

### 1. **Rendering Module** (`Source/Asta.Rendering/`)

#### SilkWindow.cs
- Implements `iWindow` interface
- Manages the main application window using Silk.NET
- Handles window lifecycle: Load, Render, Update, Closing
- Creates a window with OpenGL 3.3 context (800x600)
- Manages input through keyboard events (ESC to close)
- Delegates rendering to the `Renderer` class

#### Renderer.cs
- Handles OpenGL rendering pipeline
- Manages Vertex Array Objects (VAO), Vertex Buffer Objects (VBO), and Element Buffer Objects (EBO)
- Compiles and links vertex and fragment shaders into a shader program
- Provides three main methods:
  - `load(IWindow)`: Initializes VAO, VBO, EBO, and shader program
  - `render()`: Renders using the shader program
  - `dispose()`: Cleans up OpenGL resources

#### Shader.cs
- Loads shader source code from files
- Provides static methods:
  - `LoadVertexShader(name)`: Loads vertex shader from `Assets/Shaders/{name}.vert`
  - `LoadFragmentShader(name)`: Loads fragment shader from `Assets/Shaders/{name}.frag`
  - `LoadShaderPair(name)`: Returns both vertex and fragment shaders as a tuple
  - `LoadShaderFile(path)`: Internal file loading utility

### 2. **Shader Assets** (`Assets/Shaders/`)

#### Default.vert
- Vertex shader (GLSL 3.3)
- Takes vertex position input and passes to fragment shader
- Identity transformation (no matrix multiplication yet)

#### Default.frag
- Fragment shader (GLSL 3.3)
- Outputs orange color (1.0, 0.5, 0.2, 1.0)

## Data Flow

1. **Initialization**: SilkWindow creates window and calls Renderer.load()
2. **Shader Loading**: Renderer loads shaders via Shader class
3. **Rendering Loop**: Each frame, Renderer.render() is called
4. **Output**: Fragment shader colors the rendered geometry

## Key Design Decisions

- **Shader Files**: Shader code is externalized to `.vert` and `.frag` files for maintainability
- **Shader Class**: Centralizes shader file loading logic
- **Renderer Class**: Encapsulates all OpenGL-specific code
