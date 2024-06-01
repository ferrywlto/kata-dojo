using System.IO.Compression;

public class TetrisGame : IObservable<int[,]>, IDisposable
{
    public int[,] board = new int[20, 10];
    int speed = 1000;
    PeriodicTimer? timer;
    IShape currentShape;
    HashSet<IObserver<int[,]>> observers = [];

    public TetrisGame()
    {
        currentShape = new Square(this);
    }
    public async Task Start() 
    {
        timer?.Dispose();
        timer = new PeriodicTimer(TimeSpan.FromMilliseconds(speed));

        while(await timer.WaitForNextTickAsync())
        {
            Console.WriteLine($"loop");
            currentShape.GoDown();
            StateHasChanged();
        }  
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