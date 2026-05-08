using System.Collections.Generic;
using System.Drawing;

namespace bsc_sc_path_finder
{
    public class BfsPathFinder : IPathFinder
    {
        public List<Point> FindPath(
            Grid grid,
            Point start,
            Point goal)
        {

            if (!grid.IsWalkable(goal.X, goal.Y))
            {
                return new List<Point>();
            }

            if (start == goal)
            {
                return new List<Point>();
            }

            var queue = new Queue<Point>();
            var visited = new HashSet<Point>();
            var parents = new Dictionary<Point, Point>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                Point current = queue.Dequeue();

                if (current == goal)
                {
                    break;
                }

                foreach (Point direction in Directions)
                {
                    Point neighbour = new Point(
                        current.X + direction.X,
                        current.Y + direction.Y);

                    if (!grid.IsWalkable(
                        neighbour.X,
                        neighbour.Y))
                    {
                        continue;
                    }

                    if (visited.Contains(neighbour))
                    {
                        continue;
                    }

                    visited.Add(neighbour);

                    parents[neighbour] = current;

                    queue.Enqueue(neighbour);
                }

            }

            if (!visited.Contains(goal))
            {
                return new List<Point>();
            }

            var path = new List<Point>();

            Point step = goal;

            while (step != start)
            {
                path.Add(step);

                step = parents[step];
            }

            path.Reverse();

            return path;

        }

        private static readonly Point[] Directions =
        {
            new Point(0, -1),
            new Point(0, 1),
            new Point(-1, 0),
            new Point(1, 0)
        };
    }
}