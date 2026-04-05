public class Q3885_DesignEventManager
{
    private class EventManager
    {

        public EventManager(int[][] events)
        {

        }

        public void UpdatePriority(int eventId, int newPriority)
        {

        }

        public int PollHighest()
        {

        }
    }

    [Fact]
    public void TestCase1()
    {
        var manager = new EventManager([[5, 7], [2, 7], [9, 4]]);
        Assert.Equal(2, manager.PollHighest());
        manager.UpdatePriority(9, 7);
        Assert.Equal(5, manager.PollHighest());
        Assert.Equal(9, manager.PollHighest());
    }

    [Fact]
    public void TestCase2()
    {
        var manager = new EventManager([[4, 1], [7, 2]]);
        Assert.Equal(7, manager.PollHighest());
        Assert.Equal(4, manager.PollHighest());
        Assert.Equal(-1, manager.PollHighest());
    }
}
