namespace bsc_sc_path_finder
{
    public class Grid
    {
        public int Width { get { return tiles.GetLength(1); } }
        public int Height { get { return tiles.GetLength(0); } }

        private readonly Tile[,] tiles;

        public Grid(Tile[,] tiles)
        {
            this.tiles = tiles;
        }

        public Tile GetTile(int x, int y)
        {
            return tiles[x, y];
        }

        public bool InBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public bool IsWalkable(int x, int y)
        {
            return InBounds(x, y) && tiles[x, y].Type.IsWalkable;
        }
    }
}
