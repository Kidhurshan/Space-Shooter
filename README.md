# 🚀 Space Boy Shooter

<p align="center">
  <a href="https://kidhurshan.itch.io/space-boy">
    <img src="https://img.shields.io/badge/Play-Game-brightgreen?style=for-the-badge&logo=itch.io" alt="Play Game" width="300" />
  </a>
</p>

<p align="center">
  <a href="https://kidhurshan.itch.io/space-boy">
    <img src="https://github.com/user-attachments/assets/2da9073a-1eda-4034-a3fc-fba62110b3f9" alt="Play Space Boy Shooter" width="700" style="margin: 10px;"/>
  </a>
</p>
<h2 align="center">🎥 Project Demo</h2>
<p align="center">
  <a href="https://youtu.be/ji2YZU1Bc6g">
    <img src="https://github.com/user-attachments/assets/df9d8cf9-ec3a-455d-af2d-ba8043963d82" alt="Project Demo Video" width="400" />
  </a>
</p>

[![Unity](https://img.shields.io/badge/Unity-2022.3+-black?style=for-the-badge&logo=unity)](https://unity.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)](LICENSE)

<!-- Add game screenshot here -->
![Game Screenshot](POSTER.png)
*Screenshot: Intense combat scene with multiple enemies and weapon effects*

## 📸 Screenshots

<p align="center">
  <img src="https://github.com/user-attachments/assets/7f485816-9abb-4246-90dc-43082c79f73e" alt="Main Gameplay Screenshot" width="400" style="margin: 10px;"/>
  <img src="https://github.com/user-attachments/assets/c8f9b92e-b343-422a-8121-e0d2bbbc319d" alt="Player Profile or Character Screenshot" width="400" style="margin: 10px;"/>
</p>

*Above: Various in-game scenes and character visuals.*

## 🎮 Game Overview

Space Boy Shooter is a fast-paced 2D top-down action game that demonstrates advanced Unity development techniques. Players navigate through dynamic battle arenas, face waves of intelligent enemies, and master multiple weapon systems in an engaging space combat experience.

### Key Features

- **Multi-Weapon Combat System** - Pistol, Shotgun, and Rifle with unique characteristics
- **Advanced Enemy AI** - Three distinct enemy types with intelligent pathfinding
- **Boss Battle System** - Multi-stage boss encounters with progressive difficulty
- **Puzzle Elements** - Key-door mechanics and environmental obstacles
- **Visual Effects** - Bullet tracers, shell casings, damage popups, and screen shake
- **Smooth Controls** - Mouse-aimed shooting with dodge roll mechanics

## 🛠️ Technical Architecture

### Core Systems

```
Assets/TopDownShooter/Scripts/
├── Player/
│   ├── Player.cs                 # Main player controller
│   ├── PlayerMovementHandler.cs  # Movement and input handling
│   └── PlayerDodgeRoll.cs       # Dodge roll mechanics
├── Combat/
│   ├── Weapon.cs                 # Weapon system and stats
│   ├── AimingShoot.cs           # Aiming and shooting logic
│   └── BattleSystem.cs          # Wave-based combat management
├── AI/
│   ├── Enemy.cs                  # Base enemy class
│   ├── EnemyPathfindingMovement.cs # A* pathfinding implementation
│   ├── EnemyArcherLogic.cs      # Archer enemy behavior
│   └── EnemyChargerLogic.cs     # Charger enemy behavior
└── UI/
    ├── UI_Weapon.cs             # Weapon UI management
    ├── UI_Keys.cs               # Key collection display
    └── UI_Controls.cs           # Control instructions
```

### Design Patterns

- **Event-Driven Architecture** - Using C# events for loose coupling
- **Singleton Pattern** - For global game state management
- **Interface-Based Targeting** - Extensible targeting system
- **Component-Based Design** - Modular prefab system

## ⚔️ Gameplay Mechanics

### Combat System

The game features a sophisticated combat system with multiple weapon types:

| Weapon  | Damage | Fire Rate | Ammo | Special Effect |
|---------|--------|-----------|------|----------------|
| Pistol  | 1.2x   | 0.15s     | 8    | Balanced       |
| Shotgun | 1.9x   | 0.20s     | 5    | Spread shot    |
| Rifle   | 0.6x   | 0.09s     | 20   | Rapid fire     |

### Enemy Types

- **Minion** - Basic melee enemy with simple pathfinding
- **Archer** - Ranged enemy with projectile attacks
- **Charger** - Fast-moving enemy with aggressive behavior

### Boss Battles

Multi-stage boss encounters featuring:
- Progressive difficulty scaling
- Dynamic enemy spawning
- Health-based phase transitions
- Environmental hazard management

## 🎨 Visual & Audio Features

### Visual Effects
- Particle systems for blood, shell casings, and weapon tracers
- Screen shake and camera effects for impact feedback
- Material tinting for damage indication
- Dynamic lighting and shadows

### Audio System
- Weapon-specific sound effects
- Environmental audio cues
- Dynamic music system
- Spatial audio implementation

## 🚀 Getting Started

### Prerequisites

- Unity 2022.3 or higher
- Universal Render Pipeline (URP)
- Visual Studio 2019+ or Visual Studio Code

### Installation

1. Clone the repository
```bash
git clone https://github.com/yourusername/space-boy-shooter.git
```
2. Open the project in Unity
3. Import required packages (URP, TextMesh Pro)
4. Open `Assets/TopDownShooter/GameScene.unity`

### Controls

- **WASD** - Movement
- **Mouse** - Aim and shoot
- **1/2/3** - Switch weapons
- **Space** - Dodge roll
- **R** - Reload (when available)

## 📊 Development Metrics

- **40+ C# Scripts** with clean separation of concerns
- **20+ Prefabs** for modular game object creation
- **3 Enemy Types** with distinct AI behaviors
- **4 Weapon Types** with unique characteristics
- **Comprehensive Animation System** with state machines
- **Extensive Texture Library** with 60+ assets

## 🗂️ Project Structure

```
Assets/
├── TopDownShooter/
│   ├── Scripts/           # Core game logic
│   ├── Prefab/            # Game object prefabs
│   ├── Materials/         # Material assets
│   ├── Textures/          # Sprite and texture assets
│   ├── Animations/        # Animation controllers
│   └── KeyDoor/           # Puzzle system assets
├── _/Base/                # Base framework scripts
├── _/Stuff/               # Utility systems
└── Settings/              # Project configuration
```

## 🎯 Key Learning Outcomes

This project demonstrates proficiency in:

- **Unity 2D Development** with URP
- **Event-Driven Programming** patterns
- **AI Behavior Tree** implementation
- **Performance Optimization** for real-time games
- **User Experience Design** in action games
- **Modular Software Architecture**

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

### Development Guidelines

1. Follow the existing code style and architecture
2. Add comments for complex logic
3. Test thoroughly before submitting
4. Update documentation as needed

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Built with [Unity](https://unity.com/)
- Inspired by classic top-down shooters
- Special thanks to the Unity community for resources and support

## 📞 Contact

- **Game Link**: [Play on itch.io](https://kidhurshan.itch.io/space-boy)
- **GitHub**: [@yourusername](https://github.com/yourusername)
- **Portfolio**: [Your Portfolio Link]

---

**⭐ Don't forget to star this repository if you found it helpful!** 
