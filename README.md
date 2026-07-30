# Wave Survival System

A scalable **Wave Survival** game prototype developed in **Unity 6 (6000.3.10f1 LTS)**. The project demonstrates clean architecture, ScriptableObject-driven gameplay, object pooling, and event-driven UI.

## Features
- Player movement (New Input System)
- Auto attack with projectiles
- Multiple enemy types
- Wave-based enemy spawning
- XP collection and Level System
- Upgrade System
- Health System
- Pause & Game Over UI
- Background music & SFX
- Save System (Best Level & Best Survival Time)

## Architecture
- ScriptableObject-based data
- Factory Pattern (Enemy Spawning)
- Object Pooling (Enemies, Projectiles, XP)
- Observer Pattern (Event-driven UI)
- SOLID Principles

| Action | Key |
|---------|-----|
| Move | WASD / Arrow Keys |
| Attack | Automatic |
| Pause | Pause Button |

## Optimization
- Object Pooling
- Cached References
- Event-driven UI
- ScriptableObject Configuration
- Minimal Runtime Allocations

## Bonus Feature
- Save System using **PlayerPrefs**
- Stores Best Level and Best Survival Time

## Unity Version
**Unity 6000.3.10f1 LTS**
-
Developed as a Unity gameplay architecture assignment focusing on clean code, scalability, and performance.
