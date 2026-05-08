using System;
using System.Collections.Generic;
using System.Drawing;
using PriorityQueue;

namespace bsc_sc_path_finder
{

    public class AStarPathFinder : IPathFinder
    {
        private int Heuristic(
            Point a,
            Point b)
        {
            return
                System.Math.Abs(a.X - b.X) +
                System.Math.Abs(a.Y - b.Y);
        }

        public List<Point> FindPath(
            Grid grid,
            Point start,
            Point goal)
        {
            
            if (start == goal)
            {
                return new List<Point>();
            }

            if (!grid.IsWalkable(goal.X, goal.Y))
            {
                return new List<Point>();
            }

            var openSet =
                new SortedArrayPriorityQueue<Point>(
                    grid.Width * grid.Height);

            var closedSet =
                new HashSet<Point>();

            var parents =
                new Dictionary<Point, Point>();

            var gScores =
                new Dictionary<Point, int>();


            gScores[start] = 0;

            int startF =
                Heuristic(start, goal);

            openSet.Enqueue(
                start,
                -startF);


            while (!openSet.IsEmpty())
            {
                Point current =
                    openSet.Peek();

                openSet.Dequeue();


                if (closedSet.Contains(current))
                {
                    continue;
                }


                closedSet.Add(current);


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


                    if (closedSet.Contains(neighbour))
                    {
                        continue;
                    }


                    int tentativeG =
                        gScores[current] + 1;


                    if (!gScores.ContainsKey(neighbour) ||
                        tentativeG < gScores[neighbour])
                    {
                        gScores[neighbour] =
                            tentativeG;

                        parents[neighbour] =
                            current;


                        int fScore =
                            tentativeG +
                            Heuristic(
                                neighbour,
                                goal);


                        openSet.Enqueue(
                            neighbour,
                            -fScore);
                    }
                }
            }


            if (!closedSet.Contains(goal))
            {
                return new List<Point>();
            }


            var path =
                new List<Point>();

            Point step =
                goal;


            while (step != start)
            {
                path.Add(step);

                step =
                    parents[step];
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