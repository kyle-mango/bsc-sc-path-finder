# 🤖 Path Finder - Assessment 2 Starting Repo

This repository serves as the starting repository for **Assessment 2** of the **BSc Computing** module **UG409765 - Software Construction** and serves as the foundation for the Priority Queue class library assignment. It includes a basic path-finding visualiser and grid loader that you will extend by implementing additional algorithms and improving the internal architecture. The project also builds on the Priority Queue class library you created in Assessment 1.

## ℹ️ **Overview**
The starting application loads a map file, displays it in a grid and animates a robot moving across the terrain. The pathfinding logic is deliberately simple so you can focus on constructing implementations of Breadth-First Search (BFS) and A*, and then integrate your own Priority Queue to manage robot jobs.

Some parts of the codebase are intentionally poor to give you opportunities to improve the design.

## 🔧 **Repository Structure**
The repository includes the following main components:
- `Grid/Grid.cs` Models a grid of tiles for rendering
- `Grid/GridLoader.cs` Loads a grid from file and constructs a `Grid` object
- `Grid/GridRenderer.cs` Renders the grid of tile sprites onto the map panel
- `Grid/Robot.cs` Models the path-finding robot
- `Pathing/DumbPathFinder.cs` A simple placeholder pathfinder that produces a list of points while ignoring obstacles
- `Pathing/PathAnimator.cs` Animates the robot along a list of points from start to end
- `Tile/ITileType.cs` Interface describing tile types
- `Tile/Tile.cs` Represents a tile used to build the a `Grid`
- `Tile/TileTypes.cs` Classes representing floor, obstacle and robot tiles
- `UI/MapForm.cs` The main UI form displaying the map and handling user interaction

## ✅ **Submission**
1. Clone this repository and work on your private own copy.
2. Use version control to track all changes.
3. Please **do not** create public clones containing solutions.

## ⚠️ **Important Notes**
- Commit regularly with clear, meaningful messages that describe your progress.
- Sprite images and a test map are provided with the assessment on Brightspace.
- Read the assessment brief carefully for full requirements and marking criteria.
- Make sure your Priority Queue from Assessment 1 integrates cleanly into this project.
- Do not share or upload any completed solutions publicly.