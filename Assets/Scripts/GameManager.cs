using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public bool GameOver { get; private set; }

    private readonly Board board = new();
    private readonly BlockQueue blockQueue = new();
    private Block block;

    private const int width = 10;
    private const int height = 20;

    public TextMeshProUGUI textBoard;

    void Start()
    {
        GameOver = false;
        block = blockQueue.GetBlock();
        textBoard = GameObject.Find("Temporary Board").GetComponent<TextMeshProUGUI>();

        InvokeRepeating(nameof(MoveDown), 1f, 1f);
    }

    void Update()
    {
        if (GameOver) return;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            RotateClockwise();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            RotateCounterClockwise();
        }

        PrintBoard();
    }

    public void MoveDown()
    {
        block.Move(1, 0);

        foreach (Vector2D cell in block.CellsPositions())
        {
            if (!board.IsCellValid(cell.row, cell.column))
            {
                block.Move(-1, 0);
                board.PlaceBlock(block);
                
                if (board.IsGameOver())
                {
                    GameOver = true;
                    CancelInvoke(nameof(MoveDown));
                }

                block = blockQueue.GetBlock();
                return;
            }
        }
    }

    public void MoveLeft()
    {
        block.Move(0, -1);

        foreach (Vector2D cell in block.CellsPositions())
        {
            if (!board.IsCellValid(cell.row, cell.column))
            {
                block.Move(0, 1);
                return;
            }
        }
    }

    public void MoveRight()
    {
        block.Move(0, 1);

        foreach (Vector2D cell in block.CellsPositions())
        {
            if (!board.IsCellValid(cell.row, cell.column))
            {
                block.Move(0, -1);
                return;
            }
        }
    }

    public void RotateClockwise()
    {
        block.RotateClockwise();

        foreach (var cell in block.CellsPositions())
        {
            if (!board.IsCellValid(cell.row, cell.column))
            {
                block.RotateCounterClockwise();
                return;
            }
        }
    }

    public void RotateCounterClockwise()
    {
        block.RotateCounterClockwise();

        foreach (var cell in block.CellsPositions())
        {
            if (!board.IsCellValid(cell.row, cell.column))
            {
                block.RotateClockwise();
                return;
            }
        }
    }

    private void PrintBoard()
    {
        textBoard.text = "";
        Vector2D[] blockCells = block.CellsPositions();
        bool playerCell;

        for (int row = 0; row < height; ++row)
        {
            for (int column = 0; column < width; ++column)
            {
                playerCell = false;

                foreach (var cell in blockCells)
                {
                    if (cell.row == row && cell.column == column)
                    {
                        textBoard.text += "O";
                        playerCell = true;
                    }
                }

                if (playerCell)
                {
                    if (column == 9)
                    {
                        textBoard.text += "\n";
                    }

                    continue;
                }

                if (board.IsCellEmpty(row, column))
                {
                    textBoard.text += "_";
                }
                else
                {
                    textBoard.text += "O";
                }

                if (column == 9)
                {
                    textBoard.text += "\n";
                }
            }
        }
    }
}