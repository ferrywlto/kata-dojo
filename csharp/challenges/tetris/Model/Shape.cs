public abstract class Shape : IShape
{
    protected TetrisGame game;
    protected (int row, int col) position;
    public Shape(TetrisGame game) 
    {
        this.game = game;
        SetInitialPosition();
    }
    public virtual void SetInitialPosition()
    {
        position = new(-1, (game.board.GetLength(1) / 2) - 1);
    }
    public abstract void GoDown();
    public abstract void GoLeft();
    public abstract void GoRight();
    public abstract void RotateLeft();
    public abstract void RotateRight();
    public abstract Condition GetCondition();
    public abstract int ShapeValue { get; }
}

public enum Condition { Free, Bottom, Stuck, Lose } 