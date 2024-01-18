using dojo.leetcode;

public class Q225_ImnplementStackUsingQueues
{
    public Q225_ImnplementStackUsingQueues()
    {

    }

    public void Push(int x)
    {

    }

    public int Pop()
    {
        return 0;
    }

    public int Top()
    {
        return 0;
    }

    public bool Empty()
    {
        return false;
    }
}

public class Q225_ImnplementStackUsingQueuesTests(ITestOutputHelper output): BaseTest(output)
{
    [Fact]
    public void OfficialTestCase() 
    {
        var sut = new Q225_ImnplementStackUsingQueues();
        sut.Push(1);
        sut.Push(2);
        var top = sut.Top();
        Assert.Equal(2, top);
        var pop = sut.Pop();
        Assert.Equal(2, pop);
        Assert.False(sut.Empty());
    }
}