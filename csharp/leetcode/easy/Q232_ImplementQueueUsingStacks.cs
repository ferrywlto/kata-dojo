using dojo.leetcode;

public class Q232_ImplementQueueUsingStacks
{
    // need 2 stacks
    // whenever push, pop all stack 1 to stack 2
    // push new to stack 1
    // push all stack2 back to stack 1  
    public void Push(int x)
    {

    }

    public int Pop()
    {
        return 0;
    }

    public int Peek()
    {
        return 0;
    }

    public bool Empty()
    {
        return false;
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