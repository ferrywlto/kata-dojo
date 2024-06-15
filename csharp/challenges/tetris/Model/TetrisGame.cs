using Position = (int row, int col);
public class TetrisGame : IObservable<int[,]>, IDisposable
{
    public const int EmptyCell = 0;
    public readonly int[,] board;
    private Position position; 
    int speed { get; set; } = 500;
    int rows { get; set; } = 20;
    int cols { get; set; } = 10;
    PeriodicTimer? timer;
    Dot currentShape;
    HashSet<IObserver<int[,]>> observers = [];
    public TetrisGame()
    {
        board = new int[rows, cols];
        currentShape = new Dot();
        position = new Position(-1, cols / 2);
    }
    public async Task Start() 
    {
        timer?.Dispose();
        timer = new PeriodicTimer(TimeSpan.FromMilliseconds(speed));

        while(await timer.WaitForNextTickAsync())
        {
            Console.WriteLine($"loop");
            try
            {
                if (CanGoDown) GoDown();
                else if (position.row == -1) NotifyLost();
                else CreateNewShape();
            }
            catch (Exception e) { Console.WriteLine(e); }
            StateHasChanged();
        }  
    }
    bool CanGoDown => currentShape.CanGoDown(board, position.row, position.col);
    void GoDown() {
        currentShape.GoDown(board, position.row, position.col);
        position.row++;
    }

    void ClearBoardLine(int lineToClear)
    {
        for (var col = 0; col < board.GetLength(1); col++)
            board[lineToClear, col] = EmptyCell; 
    }
    void CopyLine(int lineFrom, int lineTo)
    {
        for (var col = 0; col < board.GetLength(1); col++) 
            board[lineTo, col] = board[lineFrom, col];        
    }
    void CopyTilToTop(int startRow)
    {
        for(var i=startRow; i>0;i--)
            CopyLine(i - i, i);
        ClearBoardLine(0);
    }
    public void CreateNewShape()
    {
        // currentShape = new Dot(this);
        currentShape = new Dot();
        position = new Position(-1, cols / 2);
    }
    public void NotifyLost()
    {
        timer?.Dispose();
        NotifyComplete();
    }
    public void HandleControl(KeyCommand command)
    {
        Console.Write($"cmd: {command}");
        if(command == KeyCommand.Down) 
        {
            if(currentShape.CanGoDown(board, position.row, position.col))
            {
                currentShape.GoDown(board, position.row, position.col);
                position.row++;
                StateHasChanged();
            }
        }
        else if(command == KeyCommand.Left)
        {
            if(currentShape.CanGoLeft(board, position.row, position.col))
            {
                currentShape.GoLeft(board, position.row, position.col);
                position.col--;
                StateHasChanged();
            }
        }
        else if(command == KeyCommand.Right)
        {
            if(currentShape.CanGoRight(board, position.row, position.col))
            {
                currentShape.GoRight(board, position.row, position.col);
                position.col++;
                StateHasChanged();
            }
        }
        else if(command == KeyCommand.RotateLeft)
        {
            currentShape.RotateLeft();
            StateHasChanged();
        }
        else if(command == KeyCommand.RotateRight)
        {
            currentShape.RotateRight();
            StateHasChanged();
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