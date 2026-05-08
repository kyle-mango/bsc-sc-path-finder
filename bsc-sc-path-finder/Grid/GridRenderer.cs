using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections.Generic;

namespace bsc_sc_path_finder
{
    public class GridRenderer
    {
        private readonly Grid grid;
        private readonly int tileSize;
        public int TileSize { get { return tileSize; } }

        public GridRenderer(Grid grid, int tileSize = 32)
        {
            this.grid = grid ?? throw new ArgumentNullException(nameof(grid));
            if (tileSize <= 0) throw new ArgumentOutOfRangeException(nameof(tileSize), "Tile size must be positive.");
            this.tileSize = tileSize;
        }

        public void Draw(Graphics g, Robot robot = null, List<Job> jobs = null)
        {
            if (g == null) throw new ArgumentNullException(nameof(g));

            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    Tile tile = grid.GetTile(x, y);
                    Image sprite = tile.Type.Sprite;

                    if (sprite == null) g.FillRectangle(Brushes.Magenta, x * tileSize, y * tileSize, tileSize, tileSize);
                    else g.DrawImage(sprite, x * tileSize, y * tileSize, tileSize, tileSize);                    
                }
            }

            if (jobs != null)
            {
                foreach (Job job in jobs)
                {
                    g.DrawImage(
                        job.Type.Sprite,

                        job.Position.X * tileSize,
                        job.Position.Y * tileSize,

                        tileSize,
                        tileSize);
                }
            }

            // always draw robot last so it’s on top
            if (robot != null)
            {
                var sprite = robot.Sprite;
                if (sprite != null)
                {

                    g.DrawImage(sprite,
                        robot.Position.X * tileSize,
                        robot.Position.Y * tileSize,
                        tileSize,
                        tileSize);
                }
            }
        }
    }
}
