using System.Collections.Generic;
using System.Drawing;

namespace bsc_sc_path_finder
{
    public class DumbPathFinder : IPathFinder
    {
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