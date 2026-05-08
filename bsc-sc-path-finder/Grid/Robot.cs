using System.Collections.Generic;
using System.Drawing;

namespace bsc_sc_path_finder
{
    public class Robot
    {
        private IPathFinder pathFinder;

        public Point Position { get; private set; }

        public Image Sprite
        {
            get { return Properties.Resources.robot; }
        }

        public Robot(
            Point startPosition,
            IPathFinder pathFinder)
        {
            Position = startPosition;
            this.pathFinder = pathFinder;
        }

        public void SetPathFinder(
            IPathFinder newPathFinder)
        {
            pathFinder = newPathFinder;
        }

        public void MoveTo(Point newPosition)
        {
            Position = newPosition;
        }

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