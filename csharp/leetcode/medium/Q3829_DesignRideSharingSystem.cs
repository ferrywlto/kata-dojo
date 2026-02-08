public class Q3829_DesignRideSharingSystem
{
    private class RideSharingSystem
    {

        private readonly Queue<int> _riders = [];
        private readonly Queue<int> _drivers = [];
        // Possible faster approach is to use a fixed array with length 1000 due to small constraint
        private readonly HashSet<int> _canceledRiders = [];

        public void AddRider(int riderId)
        {
            _canceledRiders.Remove(riderId);
            _riders.Enqueue(riderId);
        }

        public void AddDriver(int driverId)
        {
            _drivers.Enqueue(driverId);
        }

        public int[] MatchDriverWithRider()
        {
            while (_riders.Count > 0 && _canceledRiders.Contains(_riders.Peek()))
            {
                var r = _riders.Peek();
                _canceledRiders.Remove(_riders.Dequeue());
            }

            if (_riders.Count > 0 && _drivers.Count > 0)
            {
                var rider = _riders.Dequeue();
                var driver = _drivers.Dequeue();
                _canceledRiders.Remove(rider);
                return [driver, rider];
            }
            return [-1, -1];
        }

        public void CancelRider(int riderId)
        {
            _canceledRiders.Add(riderId);
        }
    }

    [Fact]
    public void TestCase1()
    {
        var sys = new RideSharingSystem();
        sys.AddRider(3);
        sys.AddDriver(2);
        sys.AddRider(1);

        var match1 = sys.MatchDriverWithRider();
        Assert.Equal([2, 3], match1);
        sys.AddDriver(5);
        sys.CancelRider(3);

        var match2 = sys.MatchDriverWithRider();
        Assert.Equal([5, 1], match2);

        var match3 = sys.MatchDriverWithRider();
        Assert.Equal([-1, -1], match3);
    }

    [Fact]
    public void TestCase2()
    {
        var sys = new RideSharingSystem();
        sys.AddRider(8);
        sys.AddDriver(8);
        sys.AddDriver(6);

        var match1 = sys.MatchDriverWithRider();
        Assert.Equal([8, 8], match1);

        sys.AddRider(2);
        sys.CancelRider(2);
        var match2 = sys.MatchDriverWithRider();
        Assert.Equal([-1, -1], match2);
    }

    [Fact]
    public void TestCase3()
    {
        var sys = new RideSharingSystem();
        sys.AddDriver(2);
        sys.CancelRider(1);
        sys.AddRider(1);
        var match = sys.MatchDriverWithRider();
        Assert.Equal([2, 1], match);
    }
}
