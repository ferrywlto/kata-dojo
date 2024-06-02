public class Square(TetrisGame game) : Shape(game)
{
    public override Condition GetCondition()
    {
        if (position.row >= game.board.GetLength(0) - 1) return Condition.Bottom;
        if (game.board[position.row + 1, position.col] == 1
        || game.board[position.row + 1, position.col + 1] == 1)
        {
            if (position.row > 0) return Condition.Stuck;
            else return Condition.Lose;
        }
        return Condition.Free;
    }

    public override void GoDown()
    {
        if (position.row == game.board.GetLength(0) - 1) return;

        if(game.board[position.row + 1, position.col] == 0 
        && game.board[position.row + 1, position.col + 1] == 0)
        {
            if (position.row >= 1)
            {
                game.board[position.row - 1, position.col] = 0;
                game.board[position.row - 1, position.col + 1] = 0;
            }

            game.board[position.row + 1, position.col] = 1;
            game.board[position.row + 1, position.col + 1] = 1;
            position.row++;               
        }
    }
    
    public override void GoLeft() 
    {
        if (position.col == 0 ) return;

        if(position.row >= 1)
        {
            if(game.board[position.row - 1, position.col - 1] == 0
            && game.board[position.row, position.col - 1] == 0)
            {
                game.board[position.row, position.col + 1] = 0;
                game.board[position.row - 1, position.col + 1] = 0;
                game.board[position.row, position.col - 1] = 1;
                game.board[position.row - 1, position.col - 1] = 1;
                position.col--;
                game.StateHasChanged();
            }
        }
        else if(position.row == 0)
        {
            if(game.board[position.row, position.col - 1] == 0)
            {
                game.board[position.row, position.col + 1] = 0;
                game.board[position.row, position.col - 1] = 1;
                position.col--;
                game.StateHasChanged();
            }
        }
    }
    public override void GoRight() 
    {
        if (position.col == game.board.GetLength(1) - 2) return;

        if(position.row >= 1)
        {
            if(game.board[position.row - 1, position.col + 2] == 0
            && game.board[position.row, position.col + 2] == 0)
            {
                game.board[position.row, position.col + 2] = 1;
                game.board[position.row - 1, position.col + 2] = 1;
                game.board[position.row, position.col] = 0;
                game.board[position.row - 1, position.col] = 0;
                position.col++;
                game.StateHasChanged();
            }
        }
        else if(position.row == 0)
        {
            if(game.board[position.row, position.col + 2] == 0)
            {
                game.board[position.row, position.col + 2] = 1;
                game.board[position.row, position.col] = 0;
                position.col++;
                game.StateHasChanged();
            }
        }
    }
    public override void RotateLeft() 
    {
        // square doesn't need to rotate
    }
    public override void RotateRight() 
    {
        // square doesn't need to rotate
    }
}