namespace Tetris.Model;
/*
Anchor: bottom-left corner
◻︎◻︎
x◻︎
*/
public class Square : IShapeRenderer
{
    public int ShapeValue => 2;

    public bool CanGoDown(int[,] board, int row, int col)
    {
        return row < board.GetLength(0) - 1 &&
            board[row + 1, col] == Tetris.EmptyCell &&
            board[row + 1, col + 1] == Tetris.EmptyCell;
    }
    public void GoDown(int[,] board, int row, int col)
    {
        if (row >= 1)
        {
            board[row - 1, col] = Tetris.EmptyCell;
            board[row - 1, col + 1] = Tetris.EmptyCell;
        }

        board[row + 1, col] = ShapeValue;
        board[row + 1, col + 1] = ShapeValue;
    }
    public bool CanGoLeft(int[,] board, int row, int col)
    {
        return col > 0 &&
        (
            (
                row > 0 &&
                board[row - 1, col - 1] == Tetris.EmptyCell &&
                board[row, col - 1] == Tetris.EmptyCell
            ) ||
            (
                row == 0 &&
                board[row, col - 1] == Tetris.EmptyCell
            )
        );
    }
    public void GoLeft(int[,] board, int row, int col)
    {
        if(row >= 1)
        {
            board[row - 1, col + 1] = Tetris.EmptyCell;
            board[row - 1, col - 1] = ShapeValue;
        }
        board[row, col + 1] = Tetris.EmptyCell;
        board[row, col - 1] = ShapeValue;
    }
    public bool CanGoRight(int[,] board, int row, int col)
    {
        var result = col < board.GetLength(1) - 2 &&
        (
            (
                row > 0 &&
                board[row - 1, col + 2] == Tetris.EmptyCell &&
                board[row, col + 2] == Tetris.EmptyCell
            ) ||
            (
                row == 0 && 
                board[row, col + 2] == Tetris.EmptyCell
            )
        );
        Console.WriteLine($"Square CanGoRight: {result}");
        return result;
    }
    public void GoRight(int[,] board, int row, int col)
    {
        if(row >= 1)
        {
            board[row - 1, col] = Tetris.EmptyCell;
            board[row - 1, col + 2] = ShapeValue;
        }
        board[row, col] = Tetris.EmptyCell;
        board[row, col + 2] = ShapeValue;
    }
    public bool CanRotateLeft(int[,] board, int row, int col) => false;
    public void RotateLeft(int[,] board, int row, int col)
    {
        throw new NotImplementedException();
    }
    public bool CanRotateRight(int[,] board, int row, int col) => false;
    public void RotateRight(int[,] board, int row, int col)
    {
        throw new NotImplementedException();
    }
}