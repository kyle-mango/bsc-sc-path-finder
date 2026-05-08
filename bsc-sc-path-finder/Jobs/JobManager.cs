using PriorityQueue;

namespace bsc_sc_path_finder
{

    /// <summary>
    /// Manages job scheduling using a priority queue.
    /// Ensures jobs are executed in order of priority.
    /// </summary>
    public class JobManager
    {
        private SortedArrayPriorityQueue<Job> queue;

        /// <summary>
        /// Creates a JobManager with a fixed maximum capacity.
        /// </summary>
        /// <param name="capacity">Maximum number of jobs that can be stored.</param>
        public JobManager(int capacity)
        {
            queue =
                new SortedArrayPriorityQueue<Job>(
                    capacity);
        }

        /// <summary>
        /// Adds a new job to the priority queue.
        /// </summary>
        /// <param name="job">The job to be added.</param>
        public void AddJob(Job job)
        {
            queue.Enqueue(
                job,
                job.Priority);
        }

        /// <summary>
        /// Retrieves and removes the highest priority job from the queue.
        /// </summary>
        /// <returns>The next job to be executed.</returns>
        public Job GetNextJob()
        {
            Job job =
                queue.Peek();

            queue.Dequeue();

            return job;
        }

        /// <summary>
        /// Checks whether any jobs remain in the queue.
        /// </summary>
        /// <returns>True if jobs are available; otherwise false.</returns>
        public bool HasJobs()
        {
            return !queue.IsEmpty();
        }
    }
}