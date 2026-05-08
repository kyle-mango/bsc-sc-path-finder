using System.Drawing;

namespace bsc_sc_path_finder
{
    public class Job
    {
        public JobType Type { get; }

        public Point Position { get; }

        public int Priority { get; }


        public Job(
            JobType type,
            Point position,
            int priority)
        {
            Type = type;
            Position = position;
            Priority = priority;
        }
    }
}