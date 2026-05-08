namespace bsc_sc_path_finder
{

    /// <summary>
    /// Represents the 2D grid world used for navigation.
    /// Stores tile data and provides utility methods for bounds checking
    /// and movement validation.
    /// </summary>
    public class Grid
    {

        /// <summary>
        /// Gets the width of the grid in tiles.
        /// </summary>
        public int Width { get { return tiles.GetLength(1); } }

        /// <summary>
        /// Gets the height of the grid in tiles.
        /// </summary>
        public int Height { get { return tiles.GetLength(0); } }

        private readonly Tile[,] tiles;

        /// <summary>
        /// Creates a new grid using a predefined tile map.
        /// </summary>
        /// <param name="tiles">2D array of tiles representing the world.</param>
        public Grid(Tile[,] tiles)
        {
            this.tiles = tiles;
        }

        /// <summary>
        /// Retrieves a tile at a specific coordinate.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <returns>The tile at the specified position.</returns>
        public Tile GetTile(int x, int y)
        {
            return tiles[x, y];
        }

        /// <summary>
        /// Checks whether a coordinate is within grid boundaries.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <returns>True if position is inside the grid; otherwise false.</returns>
        public bool InBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        /// <summary>
        /// Determines whether a tile can be walked on by the robot.
        /// Combines boundary checking and tile walkability rules.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <returns>True if the tile is accessible; otherwise false.</returns>
        public bool IsWalkable(int x, int y)
        {
            return InBounds(x, y) && tiles[x, y].Type.IsWalkable;
        }
    }
}
