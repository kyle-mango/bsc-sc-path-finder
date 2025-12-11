using System.Drawing;

namespace bsc_sc_path_finder
{
    public class Robot
    {
        public Point Position { get; private set; }
        public Image Sprite { get { return Properties.Resources.robot; } }

        public Robot(Point startPosition)
        {
            Position = startPosition;
        }

        public void MoveTo(Point newPosition)
        {
            Position = newPosition;
        }
    }
}
