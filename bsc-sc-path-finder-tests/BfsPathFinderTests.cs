using NUnit.Framework.Legacy;
using System.Drawing;
using System.Collections.Generic;

namespace bsc_sc_path_finder.Tests
{
    public class BfsPathFinderTests
    {
        private Grid Create3x3EmptyGrid()
        {
            Tile[,] tiles = new Tile[3, 3];

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    tiles[x, y] = new Tile(x, y, new FloorTileType());
                }
            }

            return new Grid(tiles);
        }

        [Test]
        public void BFS_FindsPath_WhenRouteExists()
        {
            var grid = Create3x3EmptyGrid();
            var bfs = new BfsPathFinder();

            var path = bfs.FindPath(
                grid,
                new Point(0, 0),
                new Point(2, 2)
            );

            ClassicAssert.IsNotNull(path);
            Assert.IsNotEmpty(path);

            Assert.AreEqual(new Point(2, 2), path[path.Count - 1]);
        }

        [Test]
        public void BFS_ReturnsEmpty_WhenStartEqualsGoal()
        {
            var grid = Create3x3EmptyGrid();
            var bfs = new BfsPathFinder();

            var path = bfs.FindPath(
                grid,
                new Point(1, 1),
                new Point(1, 1)
            );

            Assert.IsEmpty(path);
        }

        [Test]
        public void BFS_AvoidsObstacles()
        {
            var grid = Create3x3EmptyGrid();

            // Block middle cell
            grid.GetTile(1, 1).Type = new RockTileType();

            var bfs = new BfsPathFinder();

            var path = bfs.FindPath(
                grid,
                new Point(0, 0),
                new Point(2, 2)
            );

            foreach (var step in path)
            {
                Assert.AreNotEqual(new Point(1, 1), step);
            }

            Assert.AreEqual(new Point(2, 2), path[path.Count -1]);
        }

        [Test]
        public void BFS_ReturnsEmpty_WhenNoPathExists()
        {
            var grid = Create3x3EmptyGrid();

            // Fully block middle row
            grid.GetTile(1, 0).Type = new RockTileType();
            grid.GetTile(1, 1).Type = new RockTileType();
            grid.GetTile(1, 2).Type = new RockTileType();

            var bfs = new BfsPathFinder();

            var path = bfs.FindPath(
                grid,
                new Point(0, 0),
                new Point(2, 2)
            );

            Assert.IsEmpty(path);
        }
    }
}