public class TetrisGame : IObservable<List<int[]>>, IDisposable
{
    public const int EmptyCell = 0;
    public readonly List<int[]> board = [];

    int speed { get; set; } = 1000;
    int rows { get; set; } = 20;
    int cols { get; set; } = 10;
    PeriodicTimer? timer;
    IShape currentShape;
    HashSet<IObserver<List<int[]>>> observers = [];

    public TetrisGame()
    {
        // board = new int[rows, cols];
        for(var i=0; i<rows; i++)
        {
            board.Add(new int[cols]);
        }
        currentShape = new Square(this);
    }
    public async Task Start() 
    {
        timer?.Dispose();
        timer = new PeriodicTimer(TimeSpan.FromMilliseconds(speed));

        while(await timer.WaitForNextTickAsync())
        {
            Console.WriteLine($"loop");
            switch(currentShape.GetCondition())
            {
                case Condition.Bottom:
                case Condition.Stuck:
                    NotifyStuck();
                    break;
                case Condition.Lose:
                    NotifyLost();
                    break;
                default: 
                    currentShape.GoDown();
                    break;
            }
            ClearFilledLines();
            StateHasChanged();
        }  
    }

    private void ClearFilledLines()
    {
        var clearedLines = 0;
        var bottomRowIdx = rows - 1;
        var currentProcessingRow = bottomRowIdx;
        // while(currentProcessingRow >= 0)
        // {

        //     int[] row = new int[cols];
        //     for (int i = 0; i < cols; i++)
        //     {
        //         row[i] = board[bottomRowIdx][i];
        //     }
        //     var rowFilled = row.All(x => x != EmptyCell);
        //     if(rowFilled)
        //     {
                
        //     }
        // }
    }

    public void NotifyStuck() 
    {
        currentShape = new Square(this);
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
            currentShape.GoDown();
            StateHasChanged();
        }
        else if(command == KeyCommand.Left)
        {
            currentShape.GoLeft();
            StateHasChanged();
        }
        else if(command == KeyCommand.Right)
        {
            currentShape.GoRight();
            StateHasChanged();
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
    public IDisposable Subscribe(IObserver<List<int[]>> observer)
    {
        observers.Add(observer);
        return this;
    }
    public void Unsubcribe(IObserver<List<int[]>> observer)
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