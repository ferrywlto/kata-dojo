public class Q3885_DesignEventManager
{
    private class EventManager
    {
        private readonly Dictionary<int, int> _sourceOfTruth = [];
        private readonly PriorityQueue<int, (int priority, int eventId)> _pq;
        private static readonly Comparer<(int priority, int eventId)> comparer =
            Comparer<(int priority, int eventId)>.Create((a, b) =>
            {
                var cmp = b.priority.CompareTo(a.priority); // higher priority first
                return cmp != 0 ? cmp : a.eventId.CompareTo(b.eventId); // smaller id first
            });
        public EventManager(int[][] events)
        {
            _pq = new PriorityQueue<int, (int priority, int eventId)>(comparer);

            foreach (var evt in events)
            {
                var eventId = evt[0];
                var priority = evt[1];
                _sourceOfTruth.Add(eventId, priority);
                _pq.Enqueue(eventId, (priority, eventId));
            }
        }
        public void UpdatePriority(int eventId, int newPriority)
        {
            _sourceOfTruth[eventId] = newPriority;
            _pq.Enqueue(eventId, (newPriority, eventId));
        }
        public int PollHighest()
        {
            while (_pq.TryDequeue(out var eventId, out var entry))
            {
                if (_sourceOfTruth.TryGetValue(eventId, out var currentPriority) && currentPriority == entry.priority)
                {
                    _sourceOfTruth.Remove(entry.eventId);
                    return entry.eventId;
                }
            }

            return -1;
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

    [Fact]
    public void TestCase3()
    {
        var manager = new EventManager([[9, 4], [13, 8], [11, 6]]);
        manager.UpdatePriority(13, 5);
        Assert.Equal(11, manager.PollHighest());
    }

    [Fact]
    public void TestCase4()
    {
        var manager = new EventManager([[20, 6], [13, 2], [14, 7], [17, 2]]);
        manager.UpdatePriority(13, 8);
        manager.UpdatePriority(13, 1);
        manager.UpdatePriority(13, 8);
        Assert.Equal(13, manager.PollHighest());
        Assert.Equal(14, manager.PollHighest());
        manager.UpdatePriority(20, 5);
    }
}
