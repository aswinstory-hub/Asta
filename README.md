# Asta Engine

<p align="center">
  <img src="docs/banner.png" alt="Asta Engine Banner" width="800">
</p>

<p align="center">
A lightweight, open-source, composition-based game engine written in C#.
</p>

---

## What is Asta?

Asta is a modern game engine built around one simple idea:

> **"Composition is better than inheritance."**

Instead of building deep inheritance trees, Asta uses reusable components that can be attached to objects, making projects easier to extend, maintain and understand.

The engine is inspired by the flexibility of Godot's node system while keeping its own identity through a fully composition-based architecture.

---

# Philosophy

Asta follows a few core principles.

- 🧩 Composition over inheritance
- ⚡ Lightweight and fast
- 🎮 Designed for 2D (with future 3D support)
- 📖 Easy to learn
- 🔓 Fully open source
- 🛠 Highly customizable
- 💻 Built entirely in C#

The goal is to create an engine that stays out of your way and lets you build games instead of fighting the engine.

---

# Core Features

## Composition-Based Architecture

Everything in Asta is built using composition.

Instead of inheriting from multiple classes, objects are assembled using reusable properties.

This keeps projects modular and avoids the classic inheritance nightmare where changing one parent somehow breaks seventeen unrelated classes. Humans keep reinventing this mistake with remarkable dedication.

---

## Object System

Objects are simply containers.

Objects themselves contain very little logic.

They are responsible for:

- Holding Properties
- Organizing child Objects
- Scene hierarchy
- Transform information

Objects can be nested infinitely.

---

## Properties

Properties contain behaviour.

Every feature in Asta is implemented as a Property.

Examples:

- Sprite Renderer
- Camera
- Rigidbody
- Collider
- Script
- Audio Source
- Light

Properties can be reused between different Objects without creating complicated inheritance chains.

---

## Script System

Scripts are simply another Property.

Scripts can:

- Access other Properties
- Respond to Signals
- Control game logic
- Be reused between Objects

Because scripts are Properties themselves, they naturally integrate into the engine architecture.

---

## Signal System

Signals provide communication between Properties.

Rather than tightly coupling systems together, Properties emit and listen for Signals.

Benefits:

- Loose coupling
- Reusable systems
- Cleaner code
- Easier debugging

---

## Node-Based Workflow

The editor is built around a node hierarchy similar to modern game engines.

Objects contain Properties.

Properties contain behaviour.

Scenes are simply collections of Objects.

---

# Technology

| Technology | Purpose |
|------------|---------|
| C# | Engine language |
| .NET | Runtime |
| Silk.NET | Windowing & Input |
| OpenGL | Rendering |
| ImGui | Editor UI |

---

# Project Structure

```
Asta/
│
├── Source/
│   ├── Asta.Core/
│   ├── Asta.Rendering/
│   ├── Asta.Editor/
│   └── Asta.Runtime/
│
├── Assets/
├── Docs/
├── Examples/
└── README.md
```

---

# Engine Modules

## Asta.Core

Contains the fundamental engine systems.

Examples:

- Application
- Window
- Input
- Time
- Logger
- Scene Management
- Object System
- Property System
- Signal System

---

## Asta.Rendering

Responsible for graphics.

Includes:

- OpenGL Renderer
- Shader System
- Texture Loading
- Camera
- Meshes
- Render Pipeline

---

## Asta.Editor

The editor application.

Planned features:

- Scene Hierarchy
- Inspector
- Console
- Asset Browser
- Scene View
- Game View
- Gizmos
- Dockable Panels

---

## Asta.Runtime

The executable used to launch games.

Handles:

- Project loading
- Game startup
- Runtime loop

---

# Design Goals

- Simple API
- High performance
- Modular architecture
- Clean codebase
- Beginner friendly
- Easily extendable
- Minimal dependencies

---

# Planned Features

- Scene System
- Prefabs
- Animation System
- Audio
- Physics
- Tilemaps
- Lighting
- Particle System
- UI Framework
- Asset Pipeline
- Editor Gizmos
- Project Manager
- CLI Support
- Plugin System
- Serialization
- Hot Reloading

---

# Development Roadmap

### Stage 1 — Tiny Engine

- Window
- OpenGL Renderer
- Input
- Time
- Logger
- Triangle Rendering

---

### Stage 2 — Engine Foundation

- Object System
- Property System
- Signals
- Scene Graph
- Camera

---

### Stage 3 — Rendering

- Sprites
- Textures
- Shaders
- Batching
- Basic Lighting

---

### Stage 4 — Editor

- Docking UI
- Hierarchy
- Inspector
- Scene View
- Console

---

### Stage 5 — Gameplay

- Scripts
- Physics
- Animation
- Audio
- Prefabs

---

### Stage 6 — Version 1.0

A stable, fully usable game engine capable of developing complete games.

---

# Why "Asta"?

The name represents speed, simplicity and freedom.

The engine is designed to be powerful without becoming overwhelming.

---

# License

Asta is planned to be released under the MIT License.

---

# Contributing

Contributions, ideas, bug reports and discussions are always welcome.

As the project grows, contribution guidelines will be added.

---

# Current Status

🚧 **Under active development**

The engine is currently in its early foundation stage while the core architecture is being built.

Expect rapid changes as systems evolve.

---

> *"Build games, not inheritance trees."*
