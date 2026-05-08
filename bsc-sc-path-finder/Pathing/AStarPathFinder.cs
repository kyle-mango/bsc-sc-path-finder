using System;
using System.Collections.Generic;
using System.Drawing;
using PriorityQueue;

namespace bsc_sc_path_finder
{

    /// <summary>
    /// Implements the A* pathfinding algorithm using Manhattan distance.
    /// Finds the shortest path by combining actual cost (g-score)
    /// with heuristic cost (estimated distance to goal).
    /// </summary>
    public class AStarPathFinder : IPathFinder
    {

        /// <summary>
        /// Calculates the Manhattan distance heuristic between two points.
        /// Used to estimate remaining distance to the goal.
        /// </summary>
        private int Heuristic(
            Point a,
            Point b)
        {
            return
                System.Math.Abs(a.X - b.X) +
                System.Math.Abs(a.Y - b.Y);
        }

        /// <summary>
        /// Finds an optimal path from start to goal using A* search.
        /// Considers obstacles and prioritises lower-cost paths using a priority queue.
        /// </summary>
        /// <param name="grid">Grid representing the world.</param>
        /// <param name="start">Starting position.</param>
        /// <param name="goal">Target position.</param>
        /// <returns>List of points representing the shortest path, or empty list if no path exists.</returns>
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