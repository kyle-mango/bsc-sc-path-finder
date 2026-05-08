using System.Collections.Generic;
using System.Drawing;

namespace bsc_sc_path_finder
{

    /// <summary>
    /// Represents the robot within the simulation.
    /// Stores its current position and delegates pathfinding
    /// behaviour to an injected pathfinding strategy.
    /// </summary>
    public class Robot
    {
        private IPathFinder pathFinder;

        /// <summary>
        /// Gets the current position of the robot on the grid.
        /// </summary>
        public Point Position { get; private set; }

        /// <summary>
        /// Gets the sprite image used to visually represent the robot.
        /// </summary>
        public Image Sprite
        {
            get { return Properties.Resources.robot; }
        }

        /// <summary>
        /// Creates a new Robot instance at a starting position with a specified pathfinding strategy.
        /// </summary>
        /// <param name="startPosition">Initial position of the robot.</param>
        /// <param name="pathFinder">Pathfinding strategy used to calculate movement paths.</param>
        public Robot(
            Point startPosition,
            IPathFinder pathFinder)
        {
            Position = startPosition;
            this.pathFinder = pathFinder;
        }

        /// <summary>
        /// Changes the current pathfinding strategy at runtime.
        /// </summary>
        /// <param name="newPathFinder">New pathfinding algorithm to use.</param>
        public void SetPathFinder(
            IPathFinder newPathFinder)
        {
            pathFinder = newPathFinder;
        }

        /// <summary>
        /// Moves the robot to a new position on the grid.
        /// </summary>
        /// <param name="newPosition">Target position to move to.</param>
        public void MoveTo(Point newPosition)
        {
            Position = newPosition;
        }

        /// <summary>
        /// Calculates a path from the robot’s current position to a goal position
        /// using the currently assigned pathfinding strategy.
        /// </summary>
        /// <param name="grid">The grid representing the world environment.</param>
        /// <param name="goal">Target destination point.</param>
        /// <returns>A list of points representing the calculated path.</returns>
        public List<Point> CalculatePath(
            Grid grid,
            Point goal)
        {
            return pathFinder.FindPath(
                grid,
                Position,
                goal);
        }
    }
}