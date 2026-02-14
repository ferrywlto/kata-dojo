class Q232_ImplementQueueUsingStacks
{
    private readonly Stack<int> In = new();
    private readonly Stack<int> Out = new();

    public void Push(int x)
    {
        In.Push(x);
    }

    // Actually it didn't need to pop and restack the whole list whenever we push.
    // Do it once only when the output list is empty is more efficient
    public int Pop()
    {
        if (Out.Count == 0)
        {
            while (In.Count > 0)
            {
                Out.Push(In.Pop());
            }
        }
        return Out.Pop();
    }

    public int Peek()
    {
        if (Out.Count == 0)
        {
            while (In.Count > 0)
            {
                Out.Push(In.Pop());
            }
        }
        return Out.Peek();
    }

    public bool Empty()
    {
        return In.Count + Out.Count == 0;
    }
}

public class Q232_ImplementQueueUsingStacksTests
{
    [Fact]
    public void OfficialTestCases()
    {
        var sut = new Q232_ImplementQueueUsingStacks();
        sut.Push(1);
        sut.Push(2);
        Assert.Equal(1, sut.Peek());
        Assert.Equal(1, sut.Pop());
        Assert.False(sut.Empty());
    }
}
