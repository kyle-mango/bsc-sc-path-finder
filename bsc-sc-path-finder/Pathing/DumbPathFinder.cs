using System.Collections.Generic;
using System.Drawing;

namespace bsc_sc_path_finder
{

    /// <summary>
    /// A basic non-obstacle-aware pathfinding implementation.
    /// Moves in a straight Manhattan-style path directly toward the goal.
    /// This implementation does not consider obstacles and may pass through them.
    /// Used as a baseline or fallback movement strategy.
    /// </summary>
    public class DumbPathFinder : IPathFinder
    {

        /// <summary>
        /// Generates a simple straight-line path from start to goal using axis-aligned movement.
        /// </summary>
        /// <param name="grid">The grid world (not used in this implementation).</param>
        /// <param name="start">Starting position.</param>
        /// <param name="goal">Target position.</param>
        /// <returns>A list of points forming a direct Manhattan path.</returns>
        public List<Point> FindPath(
            Grid grid,
            Point start,
            Point goal)
        {
            var path = new List<Point>();

            int x = start.X;
            int y = start.Y;

            while (x != goal.X)
            {
                x += goal.X > x ? 1 : -1;
                path.Add(new Point(x, y));
            }

            while (y != goal.Y)
            {
                y += goal.Y > y ? 1 : -1;
                path.Add(new Point(x, y));
            }

            return path;
        }
    }
}