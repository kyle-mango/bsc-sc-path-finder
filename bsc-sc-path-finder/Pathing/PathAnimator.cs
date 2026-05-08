using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace bsc_sc_path_finder
{
    public class PathAnimator
    {
        private readonly Robot robot;
        private readonly Control targetControl;
        private readonly Timer timer;
        private List<Point> path;
        private int index;

        public bool IsRunning { get; private set; }

        public PathAnimator(Robot robot, Control targetControl, int intervalMs = 200)
        {
            this.robot = robot ?? throw new ArgumentNullException(nameof(robot));
            this.targetControl = targetControl ?? throw new ArgumentNullException(nameof(targetControl));

            timer = new Timer();
            timer.Interval = intervalMs;
            timer.Tick += Timer_Tick;
        }

        public void Start(List<Point> path)
        {
            if (path == null || path.Count == 0) throw new ArgumentException("Path cannot be null or empty");

            this.path = path;
            index = 0;
            IsRunning = true;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            IsRunning = false;
        }

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
