
public class Vector2D
{
    public int row;
    public int column;

    public Vector2D(int row, int column)
    {
        this.row = row;
        this.column = column;
    }

    public static Vector2D operator +(Vector2D v1, Vector2D v2)
    {
        return new Vector2D(v1.row + v2.row, v1.column + v2.column);
    }
}