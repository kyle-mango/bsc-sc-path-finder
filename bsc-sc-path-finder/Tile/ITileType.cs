using System.Drawing;

namespace bsc_sc_path_finder
{
    public interface ITileType
    {
        Image Sprite { get; }
        bool IsWalkable { get; }
    }
}
