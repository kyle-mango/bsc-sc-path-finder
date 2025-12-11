using System.Drawing;

namespace bsc_sc_path_finder
{
    public class FloorTileType : ITileType
    {
        public Image Sprite { get { return Properties.Resources.floor; } }
        public bool IsWalkable { get { return true; } }
    }

    public class RockTileType : ITileType
    {
        public Image Sprite { get { return Properties.Resources.rock; } }
        public bool IsWalkable { get { return false; } }
    }

    public class CraterTileType : ITileType
    {
        public Image Sprite { get { return Properties.Resources.crater; } }
        public bool IsWalkable { get { return false; } }
    }
}
