
public abstract class Block
{
    protected Vector2D[][] cells;
    protected Vector2D offset;
    protected int rotationState;

    public Vector2D[] CellsPositions()
    {
        Vector2D[] positions = new Vector2D[4];
        int count = 0;

        foreach (Vector2D cell in cells[rotationState])
        {
            positions[count] = cell + offset;
            ++count;
        }

        return positions;
    }

    public void RotateClockwise()
    {
        rotationState += 1;

        if (rotationState == cells.Length)
        {
            rotationState = 0;
        }
    }

    public void RotateCounterClockwise()
    {
        rotationState -= 1;

        if (rotationState == -1)
        {
            rotationState = (cells.Length - 1);
        }
    }

    public void Move(int rows, int columns)
    {
        offset.row += rows;
        offset.column += columns;
    }
}

public class IBlock : Block
{
    public IBlock()
    {
        offset = new(0, 3);

        cells = new Vector2D[4][];
        cells[0] = new Vector2D[] { new(1, 0), new(1, 1), new(1, 2), new(1, 3) };
        cells[1] = new Vector2D[] { new(0, 2), new(1, 2), new(2, 2), new(3, 2) };
        cells[2] = new Vector2D[] { new(2, 0), new(2, 1), new(2, 2), new(2, 3) };
        cells[3] = new Vector2D[] { new(0, 1), new(1, 1), new(2, 1), new(3, 1) };
    }
}

public class TBlock : Block
{
    public TBlock()
    {
        offset = new(0, 4);

        cells = new Vector2D[4][];
        cells[0] = new Vector2D[] { new(0, 1), new(1, 0), new(1, 1), new(1, 2) };
        cells[1] = new Vector2D[] { new(0, 1), new(1, 1), new(1, 2), new(2, 1) };
        cells[2] = new Vector2D[] { new(1, 0), new(1, 1), new(1, 2), new(2, 1) };
        cells[3] = new Vector2D[] { new(0, 1), new(1, 0), new(1, 1), new(2, 1) };
    }
}

public class JBlock : Block
{
    public JBlock()
    {
        offset = new(0, 4);

        cells = new Vector2D[4][];
        cells[0] = new Vector2D[] { new(0, 1), new(1, 1), new(2, 0), new(2, 1) };
        cells[1] = new Vector2D[] { new(0, 0), new(1, 0), new(1, 1), new(1, 2) };
        cells[2] = new Vector2D[] { new(0, 1), new(0, 2), new(1, 1), new(2, 1) };
        cells[3] = new Vector2D[] { new(1, 0), new(1, 1), new(1, 2), new(2, 2) };
    }
}

public class LBlock : Block
{
    public LBlock()
    {
        offset = new(0, 4);

        cells = new Vector2D[4][];
        cells[0] = new Vector2D[] { new(0, 1), new(1, 1), new(2, 1), new(2, 2) };
        cells[1] = new Vector2D[] { new(1, 0), new(1, 1), new(1, 2), new(2, 0) };
        cells[2] = new Vector2D[] { new(0, 0), new(0, 1), new(1, 1), new(2, 1) };
        cells[3] = new Vector2D[] { new(0, 2), new(1, 0), new(1, 1), new(1, 2) };
    }
}

public class OBlock : Block
{
    public OBlock()
    {
        offset = new(0, 4);

        cells = new Vector2D[1][];
        cells[0] = new Vector2D[] { new(1, 1), new(1, 2), new(2, 1), new(2, 2) };
    }
}

public class SBlock : Block
{
    public SBlock()
    {
        offset = new(0, 4);

        cells = new Vector2D[4][];
        cells[0] = new Vector2D[] { new(0, 1), new(0, 2), new(1, 0), new(1, 1) };
        cells[1] = new Vector2D[] { new(0, 1), new(1, 1), new(1, 2), new(2, 2) };
        cells[2] = new Vector2D[] { new(1, 1), new(1, 2), new(2, 0), new(2, 1) };
        cells[3] = new Vector2D[] { new(0, 0), new(1, 0), new(1, 1), new(2, 1) };
    }
}

public class ZBlock : Block
{
    public ZBlock()
    {
        offset = new(0, 4);

        cells = new Vector2D[4][];
        cells[0] = new Vector2D[] { new(0, 0), new(0, 1), new(1, 1), new(1, 2) };
        cells[1] = new Vector2D[] { new(0, 2), new(1, 1), new(1, 2), new(2, 1) };
        cells[2] = new Vector2D[] { new(1, 0), new(1, 1), new(2, 1), new(2, 2) };
        cells[3] = new Vector2D[] { new(0, 1), new(1, 0), new(1, 1), new(2, 0) };
    }
}