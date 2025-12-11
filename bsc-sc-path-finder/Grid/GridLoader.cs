using System;
using System.Drawing;
using System.IO;

namespace bsc_sc_path_finder
{    
    public static class GridLoader
    {
        public static (Grid grid, Point robotStart) LoadFromFile(string path)
        {
            // Throw exception if path not provided, or path is null
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("Path cannot be null or empty", nameof(path));

            // Throw exception if file does not exist
            if (!File.Exists(path)) throw new FileNotFoundException($"Grid file not found: {path}");

            // Read lines to string array
            string[] lines = File.ReadAllLines(path);

            // Validate maximum and minimum grid size
            int height = lines.Length;
            int width = lines[0].Length;
            if (width != height) throw new InvalidDataException($"Grid must be square. Found width {width} and height {height}.");
            if (width <= 0 || height <= 0) throw new InvalidDataException("Grid dimensions must be positive.");
            if (height > 20 || width > 20) throw new InvalidDataException("Grid size cannot exceed 20x20 limit");

            Tile[,] tiles = new Tile[width, height];
            Point robotStart = new Point();
            int robotStartCounter = 0;

            for (int y = 0; y < height; y++)
            {
                string row = lines[y];

                if (row.Length != width)
                {
                    string message = row.Length < width
                        ? $"Row {y + 1} has fewer columns ({row.Length}) than expected width ({width})."
                        : $"Row {y + 1} has more columns ({row.Length}) than expected width ({width}).";

                    throw new InvalidDataException(message);
                }

                for (int x = 0; x < width; x++)
                {
                    char symbol = row[x];
                    ITileType type;
                    switch (symbol)
                    {
                        case '#':
                            type = new RockTileType();
                            break;
                        case '£':
                            type = new CraterTileType();
                            break;
                        case 'R':
                            robotStart = new Point(x, y);
                            robotStartCounter++;
                            type = new FloorTileType(); // Robot stands on floor tile
                            break;
                        case 'F':
                            type = new FloorTileType();
                            break;
                        default: throw new FormatException(string.Format("Unrecognized tile symbol '{0}' at row {1}, column {2}.", symbol));
                    }
                    tiles[x, y] = new Tile(x, y, type);
                }
            }

            // Validate 1 valid robot start position provided
            if (robotStartCounter == 0) throw new InvalidDataException("Grid must contain starting robot position tile (symbol 'R')");
            if (robotStartCounter > 1) throw new InvalidDataException("Grid contains multiple starting robot positions. Only one is allowed");

            return (new Grid(tiles), robotStart);
        }
    }
}
