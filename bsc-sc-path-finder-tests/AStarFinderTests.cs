using NUnit.Framework;
using System.Drawing;
using System.Collections.Generic;

namespace bsc_sc_path_finder.Tests
{
    public class AStarPathFinderTests
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
        public void AStar_FindsPath_WhenRouteExists()
        {
            var grid = Create3x3EmptyGrid();
            var astar = new AStarPathFinder();

            var path = astar.FindPath(
                grid,
                new Point(0, 0),
                new Point(2, 2)
            );

            Assert.IsNotNull(path);
            Assert.IsNotEmpty(path);

            Assert.AreEqual(new Point(2, 2), path[path.Count - 1]);
        }

        [Test]
        public void AStar_ReturnsEmpty_WhenStartEqualsGoal()
        {
            var grid = Create3x3EmptyGrid();
            var astar = new AStarPathFinder();

            var path = astar.FindPath(
                grid,
                new Point(1, 1),
                new Point(1, 1)
            );

            Assert.IsEmpty(path);
        }

        [Test]
        public void AStar_AvoidsObstacles()
        {
            var grid = Create3x3EmptyGrid();

            // Block center
            grid.GetTile(1, 1).Type = new RockTileType();

            var astar = new AStarPathFinder();

            var path = astar.FindPath(
                grid,
                new Point(0, 0),
                new Point(2, 2)
            );

            foreach (var step in path)
            {
                Assert.AreNotEqual(new Point(1, 1), step);
            }

            Assert.AreEqual(new Point(2, 2), path[path.Count - 1]);
        }

        [Test]
        public void AStar_ReturnsEmpty_WhenNoPathExists()
        {
            var grid = Create3x3EmptyGrid();

            // Block entire middle column
            grid.GetTile(1, 0).Type = new RockTileType();
            grid.GetTile(1, 1).Type = new RockTileType();
            grid.GetTile(1, 2).Type = new RockTileType();

            var astar = new AStarPathFinder();

            var path = astar.FindPath(
                grid,
                new Point(0, 0),
                new Point(2, 2)
            );

            Assert.IsEmpty(path);
        }
    }
}