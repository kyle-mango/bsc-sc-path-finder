using System.Drawing;

namespace bsc_sc_path_finder
{

    /// <summary>
    /// Represents a single task that can be assigned to the robot.
    /// Each job has a type, a location on the grid, and a priority value
    /// used to determine execution order in the priority queue.
    /// </summary>
    public class Job
    {

        /// <summary>
        /// Gets the type definition of the job (name and visual representation).
        /// </summary>
        public JobType Type { get; }

        /// <summary>
        /// Gets the position on the grid where the job must be executed.
        /// </summary>
        public Point Position { get; }

        /// <summary>
        /// Gets the priority of the job.
        /// Higher values indicate higher execution priority.
        /// </summary>
        public int Priority { get; }

        /// <summary>
        /// Creates a new Job instance with a defined type, position, and priority.
        /// </summary>
        /// <param name="type">The job type definition.</param>
        /// <param name="position">The location where the job will be performed.</param>
        /// <param name="priority">Priority value used for scheduling execution order.</param>
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