using PriorityQueue;

namespace bsc_sc_path_finder
{
    public class JobManager
    {
        private SortedArrayPriorityQueue<Job> queue;

        public JobManager(int capacity)
        {
            queue =
                new SortedArrayPriorityQueue<Job>(
                    capacity);
        }

        public void AddJob(Job job)
        {
            queue.Enqueue(
                job,
                job.Priority);
        }

        public Job GetNextJob()
        {
            Job job =
                queue.Peek();

            queue.Dequeue();

            return job;
        }

        public bool HasJobs()
        {
            return !queue.IsEmpty();
        }
    }
}