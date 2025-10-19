# Quick Start Checklist

This is your immediate action plan to get started with Unity development.

## Today's Tasks (Getting Started)

### 1. Install Unity (30 minutes)
- [ ] Download Unity Hub from https://unity.com/download
- [ ] Install Unity 2021.3.x LTS (or 2022.3.x LTS)
- [ ] Verify installation by creating a test project

### 2. Open Project in Unity (10 minutes)
- [ ] Open Unity Hub
- [ ] Click "Add" and select this folder (`/workspaces/platformerprototype`)
- [ ] Open the project (Unity will import and set up)
- [ ] Verify no errors in Console window

### 3. Create Your First Scene (45 minutes)
- [ ] Create new Scene: `File > New Scene > 2D`
- [ ] Save as `Assets/Scenes/Level1.unity`
- [ ] Add ground platform: `GameObject > 2D Object > Sprite > Square`
  - Scale to (10, 1, 1) for ground platform
  - Position at (0, -3, 0)
  - Add `Box Collider 2D` component
- [ ] Create player: `GameObject > 2D Object > Sprite > Square`
  - Scale to (1, 1, 1)
  - Position at (0, 0, 0)
  - Add `Rigidbody2D` component
  - Add `Box Collider 2D` component
  - Add `PlayerController` script component
  - Tag as "Player"

### 4. Test Basic Movement (15 minutes)
- [ ] Set Camera position to (0, 0, -10)
- [ ] Press Play button
- [ ] Test movement with A/D or Arrow keys
- [ ] Test jumping with Spacebar
- [ ] Verify player lands on ground platform

## This Week's Goals

### Scene Setup
- [ ] Create a simple test level with multiple platforms
- [ ] Add a few collectible objects
- [ ] Test player movement and physics

### Art Placeholder
- [ ] Replace square sprites with simple art (even colored rectangles)
- [ ] Set up sprite layers (Background, Platforms, Player, Collectibles)
- [ ] Configure Camera for 2D perspective

### Physics Tuning
- [ ] Adjust player movement speed in PlayerController
- [ ] Fine-tune jump height and gravity
- [ ] Test collision detection edge cases

## Common First-Time Issues & Solutions

### "PlayerController script missing"
- Make sure `Assets/Scripts/Player/PlayerController.cs` exists
- Drag the script from Project window to Player GameObject

### "Player falls through ground"
- Ensure ground platform has `Collider2D` component
- Check that Player has `Rigidbody2D` component
- Verify layers are set correctly in Physics2D settings

### "Movement not working"
- Check Input Manager has Horizontal axis set up
- Verify PlayerController script is attached to player
- Make sure player GameObject has Rigidbody2D

### "Can't see player/camera wrong"
- Set Main Camera position to (0, 0, -10)
- Ensure Camera projection is Orthographic
- Set Camera size to 5-8 for good view

## Helpful Unity Windows
- **Scene**: Visual editor where you build levels
- **Game**: Preview of your game when you press Play
- **Hierarchy**: List of objects in current scene
- **Project**: File browser for your assets
- **Inspector**: Properties of selected object
- **Console**: Error messages and debug output

## Key Shortcuts
- `Ctrl+S`: Save scene
- `Ctrl+P`: Play/stop game
- `F`: Focus on selected object in Scene view
- `W/E/R`: Move/Rotate/Scale tools
- `V`: Vertex snap mode

---
**Ready to start?** Open Unity Hub, add this project, and follow the checklist above!