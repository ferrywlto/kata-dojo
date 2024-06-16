namespace Tetris.Model;

public class ShapeRendererFactory
{
    Random rand = new();
    Dictionary<int, IShapeRenderer> renderers;
    public ShapeRendererFactory(int[,] board, Position position)
    {
        renderers = new() 
        { 
            { 0, new Dot() }, 
            { 1, new Square() }, 
        };
    }
    public IShapeRenderer GetRenderer() 
    {
        var idx = rand.Next() % renderers.Count;
        return renderers[idx];
    }
}
public class Tetris : IObservable<int[,]>, IDisposable
{
    public const int EmptyCell = 0;
    public readonly int[,] board;
    private Position position; 
    int speed { get; set; } = 500;
    int rows { get; set; } = 20;
    int cols { get; set; } = 10;
    PeriodicTimer? timer;
    IShapeRenderer currentShape;
    HashSet<IObserver<int[,]>> observers = [];
    ShapeRendererFactory rendererFactory;
    public Tetris()
    {
        board = new int[rows, cols];
        position = new Position() 
        { 
            Row = board.GetLength(0) - 3, 
            Col = cols / 2 
        };
        rendererFactory = new ShapeRendererFactory(board, position);
        currentShape = rendererFactory.GetRenderer();

        // test data
        var filled = new int[] { 20, 20, 18, 18, 16, 0, 5, 10, 2, 20 };
        for (var i = 0; i < board.GetLength(1); i++) 
        {
            for(var j = rows-filled[i]; j<rows; j++)
            {
                board[j, i] = 1;
            }
        }
        
    }
    public void CreateNewShape()
    {
        currentShape = rendererFactory.GetRenderer();
        position.Row = -1;
        position.Col = cols / 2;
    }
    public async Task Start() 
    {
        timer?.Dispose();
        timer = new PeriodicTimer(TimeSpan.FromMilliseconds(speed));

        while(await timer.WaitForNextTickAsync())
        {
            try
            {
                if (CanGoDown) GoDown();
                else if (position.Row == -1) Lose();
                else
                {
                    ClearFilledRows();
                    CreateNewShape();
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            StateHasChanged();
        }  
    }
    bool CanGoDown => currentShape.CanGoDown(board, position.Row, position.Col);
    void GoDown() {
        currentShape.GoDown(board, position.Row, position.Col);
        position.Row++;
    }

    void ClearFilledRows()
    {
        int bottomRowIdx = board.GetLength(0) - 1;
        var rowIdx = bottomRowIdx;
        while(rowIdx > 0)
        {
            if(IsRowFilled(rowIdx))
            {
                CopyTilToTop(rowIdx);
            }
            else rowIdx--;
        }
    }
    bool IsRowFilled(int rowIdx)
    {
        var filled = true;
        for(var i=0; i<board.GetLength(1); i++)
        {
            filled = filled && board[rowIdx, i] != EmptyCell;
        }
        return filled;
    }
    void ClearBoardLine(int lineToClear)
    {
        for (var col = 0; col < board.GetLength(1); col++)
            board[lineToClear, col] = EmptyCell; 
    }
    void CopyRow(int rowFrom, int rowTo)
    {
        for (var col = 0; col < board.GetLength(1); col++) 
            board[rowTo, col] = board[rowFrom, col];        
    }
    void CopyTilToTop(int startRow)
    {
        for(var i=startRow; i>0;i--)
            CopyRow(i - 1, i);
        ClearBoardLine(0);
    }

    public void Lose()
    {
        timer?.Dispose();
        NotifyComplete();
    }
    public void HandleControl(KeyCommand command)
    {
        // Console.Write($"cmd: {command}");
        if(command == KeyCommand.Down) 
        {
            if(currentShape.CanGoDown(board, position.Row, position.Col))
            {
                currentShape.GoDown(board, position.Row, position.Col);
                position.Row++;
                StateHasChanged();
            }
        }
        else if(command == KeyCommand.Left)
        {
            if(currentShape.CanGoLeft(board, position.Row, position.Col))
            {
                currentShape.GoLeft(board, position.Row, position.Col);
                position.Col--;
                StateHasChanged();
            }
        }
        else if(command == KeyCommand.Right)
        {
            if(currentShape.CanGoRight(board, position.Row, position.Col))
            {
                currentShape.GoRight(board, position.Row, position.Col);
                position.Col++;
                StateHasChanged();
            }
        }
        else if(command == KeyCommand.RotateLeft)
        {
            if(currentShape.CanRotateLeft(board, position.Row, position.Col))
            {
                currentShape.RotateLeft(board, position.Row, position.Col);
                StateHasChanged();
            }
        }
        else if(command == KeyCommand.RotateRight)
        {
            if(currentShape.CanRotateRight(board, position.Row, position.Col))
            {
                currentShape.RotateRight(board, position.Row, position.Col);
                StateHasChanged();
            }
        }
    }
    public IDisposable Subscribe(IObserver<int[,]> observer)
    {
        observers.Add(observer);
        return this;
    }
    public void Unsubcribe(IObserver<int[,]> observer)
    {
        observers.Remove(observer);
    }
    public void StateHasChanged()
    {
        foreach (var observer in observers) observer.OnNext(board);
    }
    public void NotifyError(Exception e) 
    {
        foreach (var observer in observers) observer.OnError(e);
    }
    public void NotifyComplete()
    {
        foreach (var observer in observers) observer.OnCompleted();
    }
    public void Dispose()
    {
        timer?.Dispose();
        observers.Clear();
    }

}

public enum KeyCommand { Down, Left, Right, RotateLeft, RotateRight }

public enum CellType { Empty = 0, Yellow = 1}

public class Position 
{
    public int Row { get; set; }
    public int Col { get; set; }
}