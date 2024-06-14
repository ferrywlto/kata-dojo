/*
Anchor: bottom-left corner
◻︎◻︎
x◻︎
*/
public class Square(TetrisGame game) : Shape(game)
{
    public override int ShapeValue => 2;
    int BoardTopIdx => 0;
    int BoardBottomIdx => game.board.GetLength(0) - 1;
    int BoardLeftIdx => 0;
    int BoardRightIdx => game.board.GetLength(1) - 1;
    public override Condition GetCondition()
    {
        if (position.row >= BoardBottomIdx) return Condition.Bottom;
        if (!IsEmptyBelow)
        {
            if (position.row > 0) return Condition.Stuck;
            else return Condition.Lose;
        }
        return Condition.Free;
    }
    bool IsEmptyBelow =>
        game.board[position.row + 1, position.col] == TetrisGame.EmptyCell &&
        game.board[position.row + 1, position.col + 1] == TetrisGame.EmptyCell;

    void ClearTopHalf() 
    {
        game.board[position.row - 1, position.col] = TetrisGame.EmptyCell;
        game.board[position.row - 1, position.col + 1] = TetrisGame.EmptyCell;
    }
    void MoveDownOneLine()
    {
        game.board[position.row + 1, position.col] = ShapeValue;
        game.board[position.row + 1, position.col + 1] = ShapeValue;
    }
    public override void GoDown()
    {
        if (position.row == BoardBottomIdx) return;

        if (IsEmptyBelow)
        {
            if (position.row >= 1) ClearTopHalf();
            MoveDownOneLine();
            position.row++;               
        }
    }

    bool IsHittingLeftBorder => position.col == BoardLeftIdx;
    
    public override void GoLeft() 
    {
        if (IsHittingLeftBorder) return;

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
        // Anchor is bottom left
        if (position.col == BoardRightIdx - 1) return;

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