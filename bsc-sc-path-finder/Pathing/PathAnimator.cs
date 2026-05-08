using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace bsc_sc_path_finder
{
    /// <summary>
    /// Handles step-by-step animation of the robot along a computed path.
    /// Uses a timer to move the robot incrementally and update the UI.
    /// </summary>
    public class PathAnimator
    {
        private readonly Robot robot;
        private readonly Control targetControl;
        private readonly Timer timer;
        private List<Point> path;
        private int index;

        /// <summary>
        /// Gets whether a path animation is currently running.
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Creates a new PathAnimator responsible for moving the robot along a path.
        /// </summary>
        /// <param name="robot">Robot to animate.</param>
        /// <param name="targetControl">UI control to refresh during animation.</param>
        /// <param name="intervalMs">Time between movement steps in milliseconds.</param>
        public PathAnimator(Robot robot, Control targetControl, int intervalMs = 200)
        {
            this.robot = robot ?? throw new ArgumentNullException(nameof(robot));
            this.targetControl = targetControl ?? throw new ArgumentNullException(nameof(targetControl));

            timer = new Timer();
            timer.Interval = intervalMs;
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Starts animating the robot along a given path.
        /// </summary>
        /// <param name="path">List of points representing the path.</param>
        public void Start(List<Point> path)
        {
            if (path == null || path.Count == 0) throw new ArgumentException("Path cannot be null or empty");

            this.path = path;
            index = 0;
            IsRunning = true;
            timer.Start();
        }

        /// <summary>
        /// Stops the current animation.
        /// </summary>
        public void Stop()
        {
            timer.Stop();
            IsRunning = false;
        }

        /// <summary>
        /// Advances the animation by one step each timer tick.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (index >= path.Count)
            {
                Stop();
                ((MapForm)targetControl.FindForm())
                    .OnPathAnimationComplete();
                return;
            }

            robot.MoveTo(path[index]);
            index++;

            // Ask the UI to redraw
            targetControl.Invalidate();
        }
    }
}
