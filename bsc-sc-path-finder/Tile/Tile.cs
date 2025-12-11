namespace bsc_sc_path_finder
{
    public class Tile
    {
        public int X { get; }
        public int Y { get; }
        public ITileType Type { get; set; }

        public Tile(int x, int y, ITileType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public override string ToString()
        {
            return $"Tile: {Type} at location: X: {X}, Y: {Y}";
        }
    }
}
