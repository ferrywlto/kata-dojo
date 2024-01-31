namespace dojo.leetcode;

public class Q225_ImnplementStackUsingQueues
{
    private Queue<int> main = new(), buffer = new();

    public Q225_ImnplementStackUsingQueues()
    {

    }

    // TC:O(n), SC:O(n)
    public void Push(int x)
    {
        buffer = new();
        buffer.Enqueue(x);

        while(main.Count > 0) 
        {
            buffer.Enqueue(main.Dequeue());
        }
        main = buffer;
    }

    public int Pop()
    {
        return main.Dequeue();
    }

    public int Top()
    {
        return main.Peek();
    }

    public bool Empty()
    {
        return main.Count == 0;
    }

    public string Print()
    {
        return string.Join(',', main.AsEnumerable());
    }
}

public class Q225_ImnplementStackUsingQueuesTests
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