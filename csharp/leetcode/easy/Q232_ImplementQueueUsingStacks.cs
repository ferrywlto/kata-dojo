using dojo.leetcode;

public class Q232_ImplementQueueUsingStacks
{
    // need 2 stacks
    // whenever push, pop all stack 1 to stack 2
    // push new to stack 1
    // push all stack2 back to stack 1  

    private readonly Stack<int> Main = new();
    public void Push(int x)
    {
        var buffer = new Stack<int>();
        while(Main.Count > 0) 
        {
            buffer.Push(Main.Pop());
        }
        Main.Push(x);
        while(buffer.Count > 0)
        {
            Main.Push(buffer.Pop());
        }
    }

    public int Pop()
    {
        return Main.Pop();
    }

    public int Peek()
    {
        return Main.Peek();
    }

    public bool Empty()
    {
        return Main.Count == 0;
    }
}

public class Q232_ImplementQueueUsingStacksTests(ITestOutputHelper output) : BaseTest(output)
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