using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace bsc_sc_path_finder
{
    public partial class MapForm : Form
    {
        private GridRenderer gridRenderer;
        private Grid grid;
        private Robot robot;
        private IPathFinder pathFinder;
        private PathAnimator pathAnimator;
        private JobManager jobManager;
        private Job activeJob;

        private List<Job> jobs = new List<Job>();
        private List<JobType> jobTypes;

        public MapForm()
        {
            InitializeComponent();

            // Enable double buffering to avoid flicker on panel paint
            Panel_Map.GetType()
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .SetValue(Panel_Map, true, null);
            Cmb_PathFinder.SelectedIndex = 1;
        }

        private void Btn_LoadMap_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Text Files|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                InitGridFromFile(dialog.FileName);
            }
        }

        private void InitGridFromFile(string filePath)
        {
            try
            {
                // Call to parse map file returning formed Grid object and robot starting position
                Point robotStart = new Point();
                (grid, robotStart) = GridLoader.LoadFromFile(filePath);
                pathFinder = GetSelectedPathFinder();
                robot = new Robot(robotStart, pathFinder);

                // Setup renderer, dumb path finder and animator to use this new map
                gridRenderer = new GridRenderer(grid);
                pathAnimator = new PathAnimator(robot, Panel_Map);
                jobManager = new JobManager(50);

                jobTypes = new List<JobType>()
{
                    new JobType("Scan", Properties.Resources.robot),
                    new JobType("Repair", Properties.Resources.robot),
                    new JobType("Collect", Properties.Resources.robot),
                    new JobType("Drill", Properties.Resources.robot),
                    new JobType("Beacon", Properties.Resources.robot),
                    new JobType("Analyse", Properties.Resources.robot),
                    new JobType("Charge", Properties.Resources.robot)
                };

                jobs.Clear();


                Job job1 = new Job(
                    new JobType(
                        "Low Priority",
                        Properties.Resources.robot),
                    new Point(3, 3),
                    1);

                Job job2 = new Job(
                    new JobType(
                        "High Priority",
                        Properties.Resources.robot),
                    new Point(8, 2),
                    10);


                jobs.Add(job1);
                jobs.Add(job2);

                jobManager.AddJob(job1);
                jobManager.AddJob(job2);

                Lbl_RobotStatus.Text = "> New map loaded";
                Panel_Map.Invalidate(); // Force re-draw
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Map load failed: {ex.Message}");
            }
        }

        private IPathFinder GetSelectedPathFinder()
        {
            if (Cmb_PathFinder.SelectedItem == null)
            {
                return new AStarPathFinder();
            }

            string selected =
                Cmb_PathFinder.SelectedItem.ToString();

            if (selected == "BFS")
            {
                return new BfsPathFinder();
            }

            return new AStarPathFinder();
        }

        private void Panel_Map_Paint(object sender, PaintEventArgs e)
        {            
            if (gridRenderer != null) gridRenderer.Draw(e.Graphics, robot, jobs);
        }

        private void Panel_Map_MouseClick(
            object sender,
            MouseEventArgs e)
        {

            if (grid == null)
            {
                return;
            }


            int tileX =
                e.X / gridRenderer.TileSize;

            int tileY =
                e.Y / gridRenderer.TileSize;


            if (tileX < 0 ||
                tileX >= grid.Width ||
                tileY < 0 ||
                tileY >= grid.Height)
            {
                return;
            }


            if (e.Button == MouseButtons.Right)
            {
                Job newJob =
                    new Job(
                        jobTypes[0],
                        new Point(
                            tileX,
                            tileY),
                        5);

                jobs.Add(newJob);

                jobManager.AddJob(newJob);

                Panel_Map.Invalidate();

                return;
            }


            if (!jobManager.HasJobs())
            {
                MessageBox.Show(
                    "No jobs queued.");

                return;
            }


            activeJob =
                jobManager.GetNextJob();


            var path =
                robot.CalculatePath(
                    grid,
                    activeJob.Position);

            if (path.Count == 0)
            {
                MessageBox.Show(
                    "No valid path found.");

                jobs.Remove(activeJob);

                activeJob = null;

                Panel_Map.Invalidate();

                return;
            }

            pathAnimator.Start(path);


            Lbl_RobotStatus.Text =
                $"Executing {activeJob.Type.Name}";
        }

        public void OnPathAnimationComplete()
        {
            if (activeJob != null)
            {
                jobs.Remove(activeJob);

                activeJob = null;

                Panel_Map.Invalidate();
            }

            MessageBox.Show("Move operation complete");
        }

        private void comboBox1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            pathFinder = GetSelectedPathFinder();

            if (robot != null)
            {
                robot.SetPathFinder(pathFinder);
            }
        }
    }
}
