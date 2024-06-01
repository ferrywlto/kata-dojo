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
    public override void GoLeft() {}
    public override void GoRight() {}
    public override void RotateLeft() {}
    public override void RotateRight() {}
}