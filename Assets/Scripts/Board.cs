using UnityEngine;

public class Board : MonoBehaviour
{
    private bool[,] grid = new bool[20, 10];
    private int width = 10;
    private int height = 20;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool isCellEmpty(int row, int column)
    {
        return grid[row, column];
    }

    public void ClearRows()
    {

    }

    public void PlaceBlock(Block block)
    {

    }

    private bool isRowFull(int row)
    {
        return true;
    }
}
