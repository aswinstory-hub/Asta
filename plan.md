# Asta Engine

A lightweight, open-source, composition-based game engine written entirely in C#.

Inspired by Godot's workflow while maintaining a simple architecture focused on extensibility, readability, and ease of development.

---

# Core Philosophy

## Goals

* Lightweight
* Open Source
* Fully Customizable
* C# First
* Composition Based
* Beginner Friendly
* Cross Platform
* Fast Iteration

## Design Principles

* Objects are containers.
* Properties contain behavior.
* Scripts are Properties.
* Everything is serializable.
* Simplicity over complexity.
* Build small systems that work before adding features.

---

# Engine Architecture

## Object System

Objects are hierarchical containers.

An Object contains:

* Name
* GUID
* Parent Object
* Child Objects
* Property List

Example:

```text
Player
├── Sprite
├── CharacterBody2D
├── Health
└── PlayerController
```

Objects contain little to no functionality.

Behavior is implemented through Properties.

---

## Property System

Everything derives from Property.

```text
Property
├── Sprite
├── Camera2D
├── CharacterBody2D
├── AudioSource
├── AnimationPlayer
└── User Scripts
```

Properties:

* Can communicate directly
* Can emit signals
* Have execution priority
* Support custom user inheritance
* May have duplicate types
* Cannot have duplicate names

---

## Scripting System

Scripts are custom Properties.

Example:

```csharp
public class PlayerController : CharacterBody2D
{
}
```

Scripts are compiled into the current project's assembly.

The editor scans the assembly and automatically registers valid Property types.

Only scripts belonging to the current project are visible.

---

## Scene System

A Scene contains:

```text
Scene
└── Root Object
```

Scenes store:

* Object Hierarchy
* Properties
* References
* Serialized Data

---

## Signal System

Properties communicate through signals.

Example:

```csharp
Emit("Damaged");
Emit("Died");
```

Signals are intended for events.

Direct references are intended for data access.

---

## Reference System

Internal References:

```text
GUID
```

Editor References:

```text
Player/Weapon/Gun
```

This allows references to remain valid even when objects are renamed.

---

# Project Structure

```text
Asta/
├── Asta.sln
├── Source/
│   ├── Asta.Core/
│   ├── Asta.Rendering/
│   ├── Asta.Editor/
│   └── Asta.Runtime/
```

---

# Asta.Core

Core engine systems.

```text
Asta.Core/
├── Application.cs
├── Window.cs
├── Input.cs
├── Time.cs
└── Logger.cs
```

Responsibilities:

* Application lifecycle
* Silk.NET window management
* Input handling
* Time management
* Logging
* Core utilities

Future additions:

```text
Object.cs
Property.cs
Scene.cs
Signal.cs
Serialization.cs
GuidManager.cs
```

---

# Asta.Rendering

Rendering backend.

```text
Asta.Rendering/
├── Renderer.cs
├── Shader.cs
├── Texture.cs
├── Mesh.cs
└── Camera.cs
```

Technology:

* Silk.NET
* OpenGL

Responsibilities:

* Rendering pipeline
* Shader management
* Texture loading
* Mesh rendering
* Camera handling

Future additions:

```text
Material.cs
Framebuffer.cs
SpriteRenderer.cs
RenderTarget.cs
```

---

# Asta.Editor

ImGui editor.

```text
Asta.Editor/
├── Editor.cs
├── HierarchyPanel.cs
├── InspectorPanel.cs
└── ConsolePanel.cs
```

Responsibilities:

* Scene hierarchy
* Property inspection
* Debug console
* Project management
* Asset browsing

Future additions:

```text
AssetBrowserPanel.cs
ProjectBrowserPanel.cs
ScriptEditorPanel.cs
SceneViewPanel.cs
```

---

# Asta.Runtime

Executable entry point.

```text
Asta.Runtime/
└── Program.cs
```

Responsibilities:

* Launch engine
* Load projects
* Initialize systems
* Start editor/runtime

---

# Project System

Projects contain:

```text
MyGame/
├── Assets/
├── Scenes/
├── Scripts/
├── Cache/
├── Build/
└── Project.json
```

Project.json identifies a valid Asta project.

---

# Project Launcher

When opening:

```text
Asta.exe
```

User is presented with:

```text
Projects
├── MyGame
├── Platformer
└── Sandbox
```

Supported actions:

* Create Project
* Open Project
* Delete Project
* Clone Project

---

# Command Line Interface

Supported commands:

```bash
asta launch MyGame
```

Future commands:

```bash
asta build MyGame
asta run MyGame
asta export MyGame
```

---

# Serialization

Format:

```text
JSON
```

Reasons:

* Human readable
* Easy debugging
* Easy serialization
* Native .NET support

---

# Editor Technology

UI Framework:

```text
ImGui.NET
```

Rendering Backend:

```text
OpenGL
```

Windowing:

```text
Silk.NET Windowing
```

---

# Rendering Technology

Graphics API:

```text
OpenGL
```

Binding Library:

```text
Silk.NET
```

Future possibility:

```text
Vulkan Backend
```

without changing engine architecture.

---

# Long-Term Engine Features

## Core

* Object System
* Property System
* Scene System
* Serialization
* Signal System
* Reference System
* Project System

## Editor

* Hierarchy
* Inspector
* Console
* Asset Browser
* Project Browser
* Script Editor

## 2D

* Transform2D
* Sprite Renderer
* Camera2D
* Tilemaps
* Animation
* Physics
* Audio
* UI

## Scripting

* Reflection
* Property Discovery
* Attributes
* Assembly Loading
* Compilation

## Build System

* Windows Export
* Linux Export
* macOS Export

---

# Technologies To Learn

## C#

* Generics
* Reflection
* Delegates
* Events
* Attributes
* Assembly Loading

## Mathematics

* Vector2
* Matrix Mathematics
* Transformations
* Rotations

## Graphics Programming

* OpenGL
* Shaders
* Textures
* Buffers
* Rendering Pipeline

## ImGui

* Windows
* Docking
* Tree Views
* Custom Controls

## Roslyn

* Compilation
* Diagnostics
* Syntax Trees

## Engine Architecture

* Scene Graphs
* Component Systems
* Serialization
* Resource Management
* Game Loops

## Debugging

* Breakpoints
* Profiling
* Logging
* Memory Analysis

---

# Final Goal

Create a lightweight, open-source C# game engine that combines:

* Godot-inspired workflow
* Property-based composition
* Project-local scripting
* ImGui editor tooling
* Silk.NET rendering and windowing

while remaining simple enough for a solo developer to understand, maintain, and extend.
