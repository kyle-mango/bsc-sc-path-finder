using System;
using System.Drawing;
using System.Windows.Forms;

namespace bsc_sc_path_finder
{
    public partial class MapForm : Form
    {
        private GridRenderer gridRenderer;
        private Grid grid;
        private Robot robot;
        private DumbPathFinder dumbPathFinder;
        private PathAnimator pathAnimator;

        public MapForm()
        {
            InitializeComponent();

            // Enable double buffering to avoid flicker on panel paint
            Panel_Map.GetType()
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .SetValue(Panel_Map, true, null);
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
                robot = new Robot(robotStart);

                // Setup renderer, dumb path finder and animator to use this new map
                gridRenderer = new GridRenderer(grid);
                dumbPathFinder = new DumbPathFinder();
                pathAnimator = new PathAnimator(robot, Panel_Map);

                Lbl_RobotStatus.Text = "> New map loaded";
                Panel_Map.Invalidate(); // Force re-draw
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Map load failed: {ex.Message}");
            }
        }

        private void Panel_Map_Paint(object sender, PaintEventArgs e)
        {            
            if (gridRenderer != null) gridRenderer.Draw(e.Graphics, robot);            
        }

        private void Panel_Map_MouseClick(object sender, MouseEventArgs e)
        {
            if (grid == null) return;

            int tileX = e.X / gridRenderer.TileSize;
            int tileY = e.Y / gridRenderer.TileSize;

            // Check bounds
            if (tileX < 0 || tileX >= grid.Width || tileY < 0 || tileY >= grid.Height) return;

            Tile clickedTile = grid.GetTile(tileX, tileY);

            // Animate to clicked cell using dumb path finder
            try
            {
                var path = dumbPathFinder.FindPath(robot.Position, new Point(clickedTile.X, clickedTile.Y));
                pathAnimator.Start(path);
                Lbl_RobotStatus.Text = $"Moving to {clickedTile.ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load grid: {ex.Message}");
            }
        }

        public static void OnPathAnimationComplete()
        {
            MessageBox.Show("Move operation complete");
        }
    }
}
