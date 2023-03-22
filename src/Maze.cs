class Maze
{
    private char[,] grid;
    private int startX, startY, treasureCount;

    public Maze(string filename)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            string? line = reader.ReadLine();

            // Validasi format file
            if (line == null)
            {
                throw new FormatException("Invalid file format");
            }

            int width = line.Split(' ').Length;
            int height = 1;

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                height++;
            }

            grid = new char[height, width];
            treasureCount = 0;

            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            for (int row = 0; row < height; row++)
            {
                line = reader.ReadLine();

                // Validasi panjang baris
                if (line == null || line.Split(' ').Length != width)
                {
                    throw new FormatException("Invalid maze row length");
                }

                string[] parts = line.Split(' ');

                for (int col = 0; col < width; col++)
                {
                    // Validasi nilai array tidak null atau out of range
                    if (parts[col] == null || parts[col].Length == 0)
                    {
                        throw new FormatException("Invalid maze content");
                    }

                    grid[row, col] = parts[col][0];

                    if (parts[col][0] == 'K')
                    {
                        startX = col;
                        startY = row;
                    }
                    else if (parts[col][0] == 'T')
                    {
                        treasureCount++;
                    }
                }
            }

            // Validasi ada atau tidaknya Krusty Krab dan harta karun
            if (startX == -1 || treasureCount == 0)
            {
                throw new FormatException("Invalid maze content");
            }
        }
    }

    public bool IsAccessible(int x, int y)
    {
        if (x < 0 || x >= grid.GetLength(1) || y < 0 || y >= grid.GetLength(0))
        {
            return false;
        }
        return grid[y, x] != 'X';
    }

    public bool IsTreasure(int x, int y)
    {
        return grid[y, x] == 'T';
    }

    public int StartX => startX;

    public int StartY => startY;

    public int TreasureCount => treasureCount; // Return the number of treasures in the maze

    public char GetNode(int row, int col)
    { // Return the node at the given row and column
        return grid[row, col];
    }

    public Node GetKrustyKrab()
    { // Return the starting node
        return new Node(startY, startX);
    }
}