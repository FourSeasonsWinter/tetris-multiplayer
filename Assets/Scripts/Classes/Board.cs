
public class Board
{
    private readonly bool[,] grid = new bool[20, 10];
    private const int width = 10;
    private const int height = 20;

    public bool IsCellValid(int row, int column)
    {
        return row >= 0 && row < height && column >= 0 && column < width && IsCellEmpty(row, column);
    }

    // POLYMORPHISM
    public bool IsCellValid(Vector2D cell)
    {
        return cell.row >= 0 && cell.row < height && cell.column >= 0 && cell.column < width && IsCellEmpty(cell);
    }

    public bool IsCellEmpty(int row, int column)
    {
        return grid[row, column] == false;
    }

    public bool IsCellEmpty(Vector2D cell)
    {
        return grid[cell.row, cell.column] == false;
    }

    public bool IsGameOver()
    {
        for (int i = 0; i < width; ++i)
        {
            if (!IsCellEmpty(0, i))
            {
                return true;
            }
        }

        return false;
    }

    public int ClearRows()
    {
        int cleared = 0;

        for (int row = height - 1; row >= 0; --row)
        {
            if (IsRowFull(row))
            {
                cleared += 1;
            }
            else
            {
                MoveRowDown(row, cleared);
            }
        }

        return cleared;
    }

    public void PlaceBlock(Block block)
    {
        foreach (Vector2D cell in block.CellsPositions())
        {
            grid[cell.row, cell.column] = true;
        }
    }

    private bool IsRowFull(int row)
    {
        for (int column = 0; column < width; ++column)
        {
            if (IsCellEmpty(row, column))
            {
                return false;
            }
        }

        return true;
    }

    private void MoveRowDown(int row, int amount)
    {
        if (amount == 0) return;

        for (int column = 0; column < width; ++column)
        {
            grid[row + amount, column] = grid[row, column];
            grid[row, column] = false;
        }
    }
}
