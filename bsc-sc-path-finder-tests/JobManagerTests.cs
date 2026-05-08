using NUnit.Framework;
using System.Drawing;

namespace bsc_sc_path_finder.Tests
{
    public class JobManagerTests
    {
        [Test]
        public void AddJob_And_GetNextJob_ReturnsHighestPriorityFirst()
        {
            var manager = new JobManager(10);

            var lowPriorityJob = new Job(
                new JobType("Low", null),
                new Point(0, 0),
                1
            );

            var highPriorityJob = new Job(
                new JobType("High", null),
                new Point(1, 1),
                10
            );

            manager.AddJob(lowPriorityJob);
            manager.AddJob(highPriorityJob);

            var first = manager.GetNextJob();

            Assert.AreEqual("High", first.Type.Name);
        }

        [Test]
        public void HasJobs_ReturnsFalse_WhenEmpty()
        {
            var manager = new JobManager(5);

            Assert.IsFalse(manager.HasJobs());
        }

        [Test]
        public void HasJobs_ReturnsTrue_AfterAddingJob()
        {
            var manager = new JobManager(5);

            manager.AddJob(
                new Job(
                    new JobType("Test", null),
                    new Point(0, 0),
                    5
                )
            );

            Assert.IsTrue(manager.HasJobs());
        }

        [Test]
        public void Jobs_AreRemoved_WhenDequeued()
        {
            var manager = new JobManager(5);

            manager.AddJob(
                new Job(new JobType("A", null), new Point(0, 0), 1)
            );

            Assert.IsTrue(manager.HasJobs());

            manager.GetNextJob();

            Assert.IsFalse(manager.HasJobs());
        }

        [Test]
        public void MultipleJobs_AreReturnedInPriorityOrder()
        {
            var manager = new JobManager(10);

            manager.AddJob(new Job(new JobType("Low", null), new Point(0, 0), 1));
            manager.AddJob(new Job(new JobType("Medium", null), new Point(1, 1), 5));
            manager.AddJob(new Job(new JobType("High", null), new Point(2, 2), 10));

            var first = manager.GetNextJob();
            var second = manager.GetNextJob();
            var third = manager.GetNextJob();

            Assert.AreEqual("High", first.Type.Name);
            Assert.AreEqual("Medium", second.Type.Name);
            Assert.AreEqual("Low", third.Type.Name);
        }
    }
}