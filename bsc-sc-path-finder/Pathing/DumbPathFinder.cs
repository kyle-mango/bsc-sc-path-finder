using System.Collections.Generic;
using System.Drawing;

namespace bsc_sc_path_finder
{
    public class DumbPathFinder
    {
        public List<Point> FindPath(Point start, Point goal)
        {
            var path = new List<Point>();
            int x = start.X;
            int y = start.Y;

            // Move horizontally first
            while (x != goal.X)
            {
                if (goal.X > x) x++;
                else x--;
                path.Add(new Point(x, y));
            }

            // Then move vertically
            while (y != goal.Y)
            {
                if (goal.Y > y) y++;
                else y--;
                path.Add(new Point(x, y));
            }

            return path;
        }
    }
}
