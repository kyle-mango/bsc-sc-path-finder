using System.Collections.Generic;
using System.Drawing;

namespace bsc_sc_path_finder
{
    public interface IPathFinder
    {
        List<Point> FindPath(
            Grid grid,
            Point start,
            Point goal);
    }
}