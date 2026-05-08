using System.Collections.Generic;
using System.Drawing;

namespace bsc_sc_path_finder
{

    /// <summary>
    /// Defines a contract for pathfinding algorithms used by the robot.
    /// </summary>
    public interface IPathFinder
    {
        List<Point> FindPath(
            Grid grid,
            Point start,
            Point goal);
    }
}