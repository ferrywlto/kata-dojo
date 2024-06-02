public class Square(TetrisGame game) : Shape(game)
{
    public override void GoDown()
    {           
        if(position.row > 0)
        {
            game.board[position.row - 1, position.col] = 0;
            game.board[position.row - 1, position.col + 1] = 0;
        }
        game.board[position.row + 1, position.col] = 1;
        game.board[position.row + 1, position.col + 1] = 1;
        position.row++;

        if(position.row >= game.board.GetLength(0) - 1 
        || game.board[position.row + 1, position.col] == 1
        || game.board[position.row + 1, position.col + 1] == 1)
        {
            if(position.row == 0) game.NotifyLost();
            else game.NotifyStuck(); 
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
            }
        }
        else if(position.row == 0)
        {
            if(game.board[position.row, position.col - 1] == 0)
            {
                game.board[position.row, position.col + 1] = 0;
                game.board[position.row, position.col - 1] = 1;
                position.col--;
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
            }
        }
        else if(position.row == 0)
        {
            if(game.board[position.row, position.col + 2] == 0)
            {
                game.board[position.row, position.col + 2] = 1;
                game.board[position.row, position.col] = 0;
                position.col++;
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