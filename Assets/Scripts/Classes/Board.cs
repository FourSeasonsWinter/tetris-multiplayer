using UnityEngine.UIElements;

public class Board
{
    private readonly bool[,] grid = new bool[20, 10];
    private const int width = 10;
    private const int height = 20;

    public bool IsCellValid(int row, int column)
    {
        return row >= 0 && row < height && column >= 0 && column < width && IsCellEmpty(row, column);
    }

    public bool IsCellEmpty(int row, int column)
    {
        return grid[row, column] == false;
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

    public void ClearRows()
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
    }

    public void PlaceBlock(Block block)
    {
        foreach (Vector2D cell in block.CellsPositions())
        {
            grid[cell.row, cell.column] = true;
        }

        ClearRows();
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
