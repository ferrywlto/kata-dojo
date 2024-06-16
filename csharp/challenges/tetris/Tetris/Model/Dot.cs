namespace Tetris.Model;

public class Dot : IShapeRenderer
{
    public int ShapeValue => 1;

    public bool CanGoLeft(int[,] board, int row, int col)
    {
        return row >= 0 && 
            col > 0 && 
            board[row, col - 1] == Tetris.EmptyCell;
    }
    public void GoLeft(int[,] board, int row, int col)
    {
        board[row, col] = Tetris.EmptyCell;
        board[row, col - 1] = ShapeValue;
    }
    public bool CanGoRight(int[,] board, int row, int col)
    {
        return row >= 0 &&
            col < board.GetLength(1) - 1 && 
            board[row, col + 1] == Tetris.EmptyCell;
    }
    public void GoRight(int[,] board, int row, int col)
    {
        board[row, col] = Tetris.EmptyCell;
        board[row, col + 1] = ShapeValue;
    }
    public bool CanGoDown(int[,] board, int row, int col)
    {
        return row < board.GetLength(0) - 1 && board[row + 1, col] == Tetris.EmptyCell;
    }
    public void GoDown(int[,] board, int row, int col)
    {
        if(row >= 0)
            board[row, col] = Tetris.EmptyCell;
        board[row + 1, col] = ShapeValue;
    }

    public bool CanRotateLeft(int[,] board, int row, int col) => false;

    public bool CanRotateRight(int[,] board, int row, int col) => false;

    public void RotateLeft(int[,] board, int row, int col)
    {
        throw new NotImplementedException();
    }

    public void RotateRight(int[,] board, int row, int col)
    {
        throw new NotImplementedException();
    }
}
