public class Dot
{
    public int ShapeValue => 1;

    public bool CanGoLeft(int[,] board, int row, int col)
    {
        return row >= 0 && 
            col > 0 && 
            board[row, col - 1] == TetrisGame.EmptyCell;
    }
    public void GoLeft(int[,] board, int row, int col)
    {
        board[row, col] = TetrisGame.EmptyCell;
        board[row, col - 1] = ShapeValue;
    }
    public bool CanGoRight(int[,] board, int row, int col)
    {
        return row >= 0 &&
            col < board.GetLength(1) - 1 && 
            board[row, col + 1] == TetrisGame.EmptyCell;
    }
    public void GoRight(int[,] board, int row, int col)
    {
        board[row, col] = TetrisGame.EmptyCell;
        board[row, col + 1] = ShapeValue;
    }
    public bool CanGoDown(int[,] board, int row, int col)
    {
        Console.WriteLine($"check CanGoDown: row :{row}, bottom: { board.GetLength(0) - 1}");
        return row < board.GetLength(0) - 1 && board[row + 1, col] == TetrisGame.EmptyCell;
    }
    public void GoDown(int[,] board, int row, int col)
    {
        if(row >= 0)
            board[row, col] = TetrisGame.EmptyCell;
        board[row + 1, col] = ShapeValue;
    } 

    // public override Condition GetCondition()
    // {
    //     if (position.row == game.board.Count - 1)
    //         return Condition.Bottom;

    //     if (game.board[position.row + 1][position.col] != TetrisGame.EmptyCell)
    //     {
    //         return position.row == -1
    //             ? Condition.Lose
    //             : Condition.Stuck;
    //     }
    //     return Condition.Free;
    // }

    // public override void GoDown()
    // {
    //     if (position.row == game.board.Count - 1) return;

    //     if (game.board[position.row + 1][position.col] == TetrisGame.EmptyCell)
    //     {
    //         game.board[position.row][position.col] = TetrisGame.EmptyCell;
    //         game.board[position.row + 1][position.col] = ShapeValue;
    //     }
    // }

    // public override void GoLeft()
    // {
    //     if (position.col == 0) return;
    //     if (game.board[position.row][position.col - 1] == TetrisGame.EmptyCell)
    //     {
    //         game.board[position.row][position.col] = TetrisGame.EmptyCell;
    //         game.board[position.row][position.col - 1] = ShapeValue;
    //     }
    // }

    // public override void GoRight()
    // {
    //     if (position.col == game.board[0].Length - 1) return;
    //     if (game.board[position.row][position.col + 1] == TetrisGame.EmptyCell)
    //     {
    //         game.board[position.row][position.col] = TetrisGame.EmptyCell;
    //         game.board[position.row][position.col + 1] = ShapeValue;
    //     }
    // }

    public void RotateLeft()
    {
        
    }

    public void RotateRight()
    {
        
    }
}
