# Call of War
### *A Tactical Shooter — Inspired by IGI & Delta Force*

> *"Precision. Strategy. Courage. Every mission is a test of your will."*
GAME LINK: https://itch.io/e/26896858/ibrhaimbinahmed-published-call-of-war
---

## 📋 Table of Contents

1. [Game Overview](#1-game-overview)
2. [Inspiration & Vision](#2-inspiration--vision)
3. [Core Gameplay](#3-core-gameplay)
4. [Key Features](#4-key-features)
5. [Audio System](#5-audio-system)
6. [Mission Design](#6-mission-design)
7. [Game Mechanics](#7-game-mechanics)
8. [Technical Architecture](#8-technical-architecture)
9. [Asset & Art Direction](#9-asset--art-direction)
10. [Controls](#10-controls)
11. [System Requirements](#11-system-requirements)
12. [Installation](#12-installation)
13. [Unity Project Structure](#13-unity-project-structure)
14. [Credits](#14-credits)
15. [License](#15-license)

---

## 1. Game Overview

**Call of War** is a released offline single-player tactical first-person shooter built in **Unity 2023 LTS (C#)**. It places you in the boots of an elite special forces operative operating deep behind enemy lines — outnumbered, outgunned, and relying entirely on skill, patience, and battlefield awareness.

Inspired by the golden era of military tactical shooters — **IGI: I'm Going In** and **Delta Force** — the game does not chase the trends of the modern FPS genre. There is no regenerating health, no waypoint babysitting, and no linear corridor handholding.

![Call of War Gameplay Screenshot](screenshot.png)

| Attribute | Detail |
|---|---|
| **Engine** | Unity 2023 LTS |
| **Language** | C# |
| **Genre** | Tactical First-Person Shooter |
| **Mode** | Single-Player Offline |
| **Platform** | PC — Windows 10 / 11 (64-bit) |
| **Status** |  Released |
| **Inspired By** | IGI: I'm Going In, Delta Force |

---

## 2. Inspiration & Vision

### The Golden Era

The late 1990s and early 2000s produced some of the most demanding and rewarding military shooters ever made. **IGI** gave players vast maps, required genuine pre-mission planning, and punished careless play with alert enemies. **Delta Force** put you alone in massive open environments with nothing but your wits and a rifle.

These were not games that held your hand. They were games that respected you.

### What We Built

The mainstream FPS genre moved toward spectacle over substance — regenerating health, infinite checkpoints, and linear cinematic corridors. **Call of War** moves in the opposite direction: a single focused mission, a single clear objective, and no margin for error.

---

## 3. Core Gameplay

At its heart, the game is about **decisions under pressure**.

You are dropped into a daytime combat zone populated by enemy soldiers. Your mission is simple: **eliminate every enemy**. There are no secondary objectives, no extraction timers, and no side missions. The game ends when the last enemy falls — or when you do.

You must manage your ammunition carefully, stay mobile, and take calculated shots. Every kill rewards you with extra magazines, so controlled aggression keeps you supplied. Careless fire leaves you empty with no way to resupply other than through combat.

---

## 4. Key Features

###  Hitscan Combat System

Shooting is immediate and responsive. When the player fires, a raycast projects from the center of the camera — if it connects with an enemy, damage is applied instantly. There is no bullet travel time and no bullet drop. What you aim at is what you hit, as long as you are within the weapon's effective range. This keeps combat fast, readable, and skill-dependent. Shots that miss enemies instead produce a surface impact effect on whatever they strike.

---

### Enemy AI — Patrol, Pursue, Shoot

Enemies operate on a distance-based awareness system with three distinct states.

While undisturbed, enemies patrol between a set of waypoints in randomised order — their routes are never fully predictable. The moment the player enters their vision radius, they abandon the patrol, fix on the player's position, and close the distance. Once the player is within shooting range, the enemy stops and opens fire on a cooldown-based interval.

An enemy that has spotted the player does not reset. Both their vision and shooting radii expand dramatically upon first awareness. Hitting an enemy also triggers full alert immediately — there is no safe way to engage at range without being noticed. Once aware, they remain hostile for the rest of the session.

---

### Health System

The player has a single health bar starting at 120 points. Each enemy shot deals 5 damage. Health does not regenerate at any point — every hit is permanent for the duration of the session. When health reaches zero, the player dies and the game over screen loads. There are no medkits, no field dressings, and no recovery of any kind. Staying alive means not getting hit.

---

###  Ammunition & Magazine Reward System

The player starts with a rifle loaded to 40 rounds and 12 magazines in reserve. Ammunition is consumed with every shot. When the active magazine runs dry, the weapon reloads automatically — the player cannot fire and cannot move during the reload window until the animation completes.

Killing an enemy rewards the player with 4 additional magazines. This creates a direct incentive loop: aggressive, accurate play replenishes your supply, while wasted shots leave you at risk of running out.

---

###  Win & Lose Conditions

The HUD displays the number of remaining enemies in real time. When the last enemy is eliminated, the game transitions immediately to the victory screen. If the player's health reaches zero at any point, the game transitions to the game over screen after a brief delay to allow the death sequence to finish.

---

###  No Save System

There are no checkpoints and no mid-session saves. Each run is played from start to finish in one sitting. Death means restarting from the beginning. This reflects the design philosophy of the games that inspired it — play carefully, not carelessly.

---

## 5. Audio System

Sound in **Call of War** is both atmospheric and functional — it tells you where enemies are and what they are doing.

**Gunshots** produce a consistent audio signature on every fire. There is no variation based on surface material — every shot sounds the same regardless of what it strikes. This keeps combat audio clean and predictable.

**Footsteps** are tied directly to the player animation. Audio clips from a randomised pool play at the exact footfall keyframes of the walk and run animations, ensuring sound is always in sync with the character's movement rather than approximated by a timer.

**Enemy fire** produces a distinct audio cue every time an enemy shoots, giving the player an audible warning of incoming fire.

**Player hurt** plays an audio cue whenever the player takes damage, providing immediate feedback even if the health bar change is not noticed visually.

---

## 6. Mission Design

### Mission Structure

The mission follows a simple three-phase flow:

**Insertion** — the player loads into the daytime scene with all enemies active and patrolling.

**Execution** — locate and eliminate every enemy. The HUD tracks the count in real time.

**Conclusion** — if all enemies are dead, the victory screen loads. If the player's health reaches zero, the game over screen loads.

### The Objective

There is one objective: kill every enemy. There are no secondary targets, no collectibles, no timed extraction, and no branching paths. The entire design pressure of the game is focused on this single, clear goal.

### Environment

The mission takes place in a fully lit **daytime environment** under consistent weather conditions. There is no time-of-day shift and no weather variation during a session. Sight lines are clear at all times — environmental conditions do not obscure the player or the enemies.

---

## 7. Game Mechanics

### Movement System

| State | Description |
|---|---|
| **Walk** | Standard movement speed in any direction — WASD or arrow keys |
| **Sprint** | Increased movement speed — hold Left or Right Shift with a movement key |
| **Jump** | Single jump, available only when the player is grounded |

These are the only movement states available. There is no crouch, no prone, no swim, and no lean. The movement system is intentionally direct — challenge comes from positioning and aim, not from complex movement options.

### Weapon Handling

The player carries a single rifle. Holding the left mouse button fires continuously. The weapon fires as fast as the input is held — there is no fire rate cap visible to the player.

Holding the right mouse button activates aim-down-sights mode, switching from the default third-person camera to a closer aim camera and swapping the HUD to the ADS overlay. Releasing the right mouse button returns to third-person view immediately.

**Reload** triggers automatically when the current magazine empties. Movement is disabled for the full duration of the reload animation. Reloading is a genuine window of vulnerability — plan when to expend your last round.

**Recoil** is applied on every shot with a slight randomised camera kick that must be managed during sustained fire.

---

## 8. Technical Architecture

### Engine Configuration

| Setting | Value |
|---|---|
| **Engine** | Unity 2023 LTS |
| **Render Pipeline** | Universal Render Pipeline (URP) |
| **Physics** | Unity PhysX — CharacterController for player, NavMeshAgent for enemies |
| **Audio** | Unity AudioSource with PlayOneShot pattern throughout |
| **Animation** | Unity Animator with bool-parameter state machines on player and enemies |
| **Input** | Unity Legacy Input System |
| **Navigation** | Unity NavMesh baked per level — used by enemies during pursuit |
| **Scenes** | Three named scenes: `scene_day`, `Win`, `gameOver` |

### Script Overview

| Script | Responsibility |
|---|---|
| `character_mov.cs` | Player movement, gravity, health tracking, enemy count, win and lose scene transitions |
| `adjust.cs` | Adapter bridge — receives damage and score events from enemies and routes them to the correct player components |
| `Rifle.cs` | Ammo management, magazine tracking, hitscan shooting, muzzle flash, auto-reload coroutine, UI text updates |
| `Enemy.cs` | Enemy patrol via waypoint MoveTowards, pursuit via NavMeshAgent, hitscan shooting, death handling |
| `footStepsSound.cs` | Plays a random clip from an audio pool — called by Animation Events at footfall keyframes |
| `switchCamera.cs` | Toggles between third-person and ADS cameras; manages HUD canvas visibility |
| `objects.cs` | Tracks health on destructible environment objects and destroys them when health is depleted |
| `controller.cs` | UI scene navigation — maps menu buttons to scene load calls |

### System Communication Flow

Enemies and the player never communicate directly. When the rifle's raycast hits an enemy, it calls the enemy's damage function. When the enemy dies, it locates the `adjust` component on the player object and calls a score function through it — which both grants extra magazines and decrements the enemy count. When an enemy's raycast hits the player, it again goes through `adjust` to apply health damage. This keeps all systems loosely connected and independently maintainable without hard dependencies between scripts.

---

## 9. Asset & Art Direction

### Visual Style

Grounded military realism — not hyper-stylised, not photorealistic. Strong directional daylight, a slightly desaturated palette, and clear sight lines suited to the open combat environment. The visual language is consistent with the early-2000s tactical shooter aesthetic that inspired the project.

### HUD Layout

```
┌──────────────────────────────────────────────────────────┐
│  [TOP-LEFT]                                              │
│  Health: 120         ← Reduces with each enemy hit       │
│  ENEMIES LEFT: X     ← Live count, decrements on kill    │
│                                                          │
│  [BOTTOM]                                                │
│  Ammo: 40            ← Current rounds in magazine        │
│  Mag: 12             ← Remaining magazines               │
│                                                          │
│  [POP-UP NOTIFICATIONS — timed]                         │
│  "AMMO OUT"          ← Shown for 1s when mags = 0       │
│  "NEW MAG"           ← Shown for 0.4s on enemy kill     │
│                                                          │
│  [ADS OVERLAY — visible only while right mouse held]    │
│  Aim crosshair                                           │
└──────────────────────────────────────────────────────────┘
```

---

## 10. Controls

| Action | Input |
|---|---|
| Move | `W` `A` `S` `D` / Arrow Keys |
| Sprint | `Left Shift` or `Right Shift` + movement |
| Jump | `Space` — grounded only |
| Fire | `Left Mouse Button` — hold to fire |
| Aim Down Sights | `Right Mouse Button` — hold to aim |
| Reload | Automatic — triggers when magazine is empty |

---

## 11. System Requirements

### Minimum

| Component | Spec |
|---|---|
| **OS** | Windows 10 (64-bit) |
| **CPU** | Intel Core i5-6600 / AMD Ryzen 5 1600 |
| **GPU** | NVIDIA GTX 1060 6GB / AMD RX 580 |
| **RAM** | 8 GB |
| **Storage** | 15 GB |
| **DirectX** | Version 11 |

### Recommended

| Component | Spec |
|---|---|
| **OS** | Windows 10 / 11 (64-bit) |
| **CPU** | Intel Core i7-9700K / AMD Ryzen 7 3700X |
| **GPU** | NVIDIA RTX 2070 / AMD RX 6700 XT |
| **RAM** | 16 GB |
| **Storage** | 15 GB SSD |
| **DirectX** | Version 12 |

---

## 12. Installation

```
1. Download CallOfWar_Setup.exe from the Releases page
2. Run the installer and follow the setup wizard
   Default path: C:\Program Files\CallOfWar\
3. Launch from the desktop shortcut or Start Menu
4. On first launch — select a graphics preset: Low / Medium / High / Ultra
```

### For Developers (Source Build)

```bash
git clone https://github.com/[your-username]/call-of-war.git
cd call-of-war
git lfs pull

# Open in Unity Hub → Add project → select folder
# Unity version: 2023 LTS
# Entry scene: Assets/Scenes/MainMenu.unity
# Build: File → Build Settings → PC, Mac & Linux Standalone → Windows x64 → Build
```

---

## 13. Unity Project Structure

```
CallOfWar/
│
├── Assets/
│   │
│   ├── Scenes/
│   │   ├── scene_day.unity          ← Main gameplay level (daytime)
│   │   ├── Win.unity                ← Victory screen
│   │   ├── gameOver.unity           ← Game over screen
│   │   └── MainMenu.unity           ← Entry point
│   │
│   ├── Scripts/
│   │   ├── character_mov.cs
│   │   ├── adjust.cs
│   │   ├── Rifle.cs                 ← class: NewBehaviourScript
│   │   ├── Enemy.cs
│   │   ├── footStepsSound.cs        ← class: FootstepsSound
│   │   ├── switchCamera.cs
│   │   ├── objects.cs
│   │   └── controller.cs
│   │
│   ├── Audio/
│   │   ├── SFX/
│   │   │   ├── Weapons/
│   │   │   ├── Enemy/
│   │   │   ├── Player/
│   │   │   └── Footsteps/
│   │   └── Music/
│   │
│   ├── Prefabs/
│   │   ├── Player/
│   │   ├── Enemy/
│   │   └── FX/
│   │       ├── MuzzleSpark.prefab
│   │       ├── ImpactEffect.prefab
│   │       └── GoreEffect.prefab
│   │
│   ├── Animations/
│   │   ├── Player/                  ← Idle, Walk, Running, Jump, Fire, FireWalk,
│   │   │                               IdleAim, WalkAim, Reloading
│   │   └── Enemy/                   ← Walk, AimRun, Shoot, Die
│   │
│   ├── Models/
│   ├── Textures/
│   ├── Materials/
│   └── UI/
│       ├── HUD_Canvas/
│       ├── AimCanvas/
│       └── Overlays/
│
├── Packages/
├── ProjectSettings/
├── .gitignore
└── README.md
```

---

## 14. Credits

**Call of War** is a solo-developed project. Every system, scene, script, and asset was designed, built, and integrated by a single developer.

| Role | Name |
|---|---|
| **Sole Developer — Design, Programming, Art & Direction** | [Your Name] |

### Acknowledgements

- Inspired by **Innerloop Studios** (IGI: I'm Going In) and **NovaLogic** (Delta Force)
- Built with **Unity 2023 LTS** — unity.com

---

## 15. License

```
All Rights Reserved © [Year] [Your Name]

This software and its associated source code are proprietary.
Redistribution, modification, or commercial use without explicit
written permission from the rights holder is strictly prohibited.
```

---

<div align="center">

**"Take up arms. Dive into the action. Prove yourself as a master of combat."**

*Built in Unity. Inspired by legends. Made by one.*

</div>
