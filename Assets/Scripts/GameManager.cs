using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public bool GameOver { get; private set; }
    public TMP_Text playerNameLabel;
    public TextMeshProUGUI textBoard;

    private readonly Board board = new();
    private readonly BlockQueue blockQueue = new();
    private Block block;

    private const int width = 10;
    private const int height = 20;

    void Start()
    {
        GameOver = false;
        block = blockQueue.GetBlock();

        if (TitleManager.Instance != null)
        {
            playerNameLabel.text = TitleManager.Instance.PlayerName;
        }

        InvokeRepeating(nameof(MoveDown), 1f, 1f);
    }

    void Update()
    {
        if (GameOver) return;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            RotateClockwise();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RotateCounterClockwise();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Drop();
        }

        PrintBoard();
    }

    public bool MoveDown()
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
                return true;
            }
        }

        return false;
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

    public void Drop()
    {
        bool placed;

        do
        {
            placed = MoveDown();
        }
        while (placed == false);
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