public class Q3814_DesignAuctionSystem(ITestOutputHelper output)
{
    private class AuctionSystem {
        class DescComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }

        // itemId -> userId
        // cache
        Dictionary<int, int> HighestBidder = [];

        // userId -> itemId -> amount
        // Dictionary<int, Dictionary<int, int>> userBids = [];

        // itemId -> amount -> userId        
        Dictionary<int, SortedDictionary<int, SortedSet<int>>> itemAmountUsers = [];

        private readonly ITestOutputHelper _output;
        public AuctionSystem(ITestOutputHelper output) {
            _output = output;
        }
        
        public void AddBid(int userId, int itemId, int bidAmount) {
            var comparer = new DescComparer();
            var sortedSet = new SortedSet<int>(comparer);
            var sortedDict = new SortedDictionary<int, SortedSet<int>>(comparer);

            itemAmountUsers.TryAdd(itemId, sortedDict);
            itemAmountUsers[itemId].TryAdd(bidAmount, sortedSet);

            var amountHistory = itemAmountUsers[itemId];

            // Need to clear existing 
            foreach(var history in amountHistory)
            {
                var users = history.Value;
                users.Remove(userId);
            }
            amountHistory[bidAmount].Add(userId);

            var historyToRemove = new List<int>();
            foreach(var history in amountHistory)
            {
                if(history.Value.Count == 0)
                {
                    historyToRemove.Add(history.Key);
                }
            }
            foreach(var h in historyToRemove)
            {
                amountHistory.Remove(h);
            }

            UpdateHighestBidder(itemId);

            _output.WriteLine("--- Debug: AddBid ---");
            // DebugUserBids();
            DebugAuctions();
        }
        
        public void UpdateBid(int userId, int itemId, int newAmount) {
            AddBid(userId, itemId, newAmount);

            // var itemAmountHistory = itemAmountUsers[itemId];

            // // Bid on same amount
            // itemAmountHistory.TryAdd(newAmount, new SortedSet<int>(new DescComparer()));
            
            // var amountHistory = itemAmountUsers[itemId];
            // // Need to clear existing
            // foreach(var history in amountHistory)
            // {
            //     var users = history.Value;
            //     users.Remove(userId);
            // }            
            // itemAmountUsers[itemId][newAmount].Add(userId);

            // UpdateHighestBidder(itemId);

            _output.WriteLine("--- Debug: UpdateBid ---");
            // DebugUserBids();
            DebugAuctions();            
        }
        
        private void UpdateHighestBidder(int itemId)
        {
            if(itemAmountUsers.ContainsKey(itemId))
            {
                var amountHistory = itemAmountUsers[itemId];
                if(amountHistory.Count == 0) {
                    HighestBidder[itemId] = -1;    
                }
                else
                {
                    var highestAmountUsers = amountHistory.First().Value;
                    if(highestAmountUsers.Count == 0)
                    {
                        HighestBidder[itemId] = -1;    
                    }
                    else
                    {
                        HighestBidder[itemId] = highestAmountUsers.First();
                    }
                }
            }
            else
            {
                HighestBidder[itemId] = -1;
            }
        }

        public void RemoveBid(int userId, int itemId) {
            var item = itemAmountUsers[itemId];
            var itemAmountToRemove = new List<int>();

            foreach(var amountHistory in item)
            {
                var users = amountHistory.Value;
                users.Remove(userId);
                
                if(users.Count == 0)
                {
                    itemAmountToRemove.Add(amountHistory.Key);
                }
            }

            foreach(var amount in itemAmountToRemove)
            {
                item.Remove(amount);
            }

            if(item.Count == 0)
            {
                itemAmountUsers.Remove(itemId);
            }

            UpdateHighestBidder(itemId);

            _output.WriteLine("--- Debug: RemoveBid ---");

            DebugAuctions();
        }
        
        public int GetHighestBidder(int itemId) {
            if(HighestBidder.TryGetValue(itemId, out var value))
            {
                return value;
            }
            return -1;
        }

        public void DebugAuctions()
        {
            _output.WriteLine("--- DebugAuctions ---");
            foreach(var item in itemAmountUsers)
            {
                _output.WriteLine($"Item {item.Key}");
                foreach(var amountHistory in item.Value)
                {
                    _output.WriteLine($"Amount: {amountHistory.Key}, bidders: {string.Join(',', amountHistory.Value)}");
                }
            }
        }        
    }
    
    [Fact]
    public void Test()
    {
        var system = new AuctionSystem(output);
        system.AddBid(1, 7, 5);
        system.AddBid(2, 7, 6);
        Assert.Equal(2, system.GetHighestBidder(7));
        system.UpdateBid(1, 7, 8);
        Assert.Equal(1, system.GetHighestBidder(7));
        system.RemoveBid(2, 7);
        Assert.Equal(1, system.GetHighestBidder(7));
        Assert.Equal(-1, system.GetHighestBidder(3));

        system.RemoveBid(1, 7);
        Assert.Equal(-1, system.GetHighestBidder(7));
    }

    [Fact]
    public void Test2()
    {
        var system = new AuctionSystem(output);
        Assert.Equal(-1, system.GetHighestBidder(43));
        system.AddBid(54, 36, 2858);
        system.RemoveBid(54, 36);
        Assert.Equal(-1, system.GetHighestBidder(15));
        Assert.Equal(-1, system.GetHighestBidder(64));
        Assert.Equal(-1, system.GetHighestBidder(38));
        system.AddBid(17, 52, 559);
        system.RemoveBid(17, 52);
        Assert.Equal(-1, system.GetHighestBidder(37));
        Assert.Equal(-1, system.GetHighestBidder(50));
        Assert.Equal(-1, system.GetHighestBidder(60));
        Assert.Equal(-1, system.GetHighestBidder(57));
        Assert.Equal(-1, system.GetHighestBidder(37));
        system.AddBid(61, 45, 1348);
        system.RemoveBid(61, 45);
        Assert.Equal(-1, system.GetHighestBidder(13));
        Assert.Equal(-1, system.GetHighestBidder(8));
        Assert.Equal(-1, system.GetHighestBidder(39));
        Assert.Equal(-1, system.GetHighestBidder(25));
        Assert.Equal(-1, system.GetHighestBidder(59));
        system.AddBid(32, 60, 250);
        system.RemoveBid(32, 60);
        Assert.Equal(-1, system.GetHighestBidder(12));
        Assert.Equal(-1, system.GetHighestBidder(34));
        Assert.Equal(-1, system.GetHighestBidder(4));
        system.AddBid(21, 60, 450);
        system.AddBid(19, 49, 3094);
        system.AddBid(21, 24, 3664);
        system.RemoveBid(21, 24);
        system.UpdateBid(19, 49, 3628);
        system.AddBid(20, 33, 2616);
        system.AddBid(4, 62, 2924);
        system.UpdateBid(4, 62, 786);
        system.RemoveBid(20, 33);
        system.RemoveBid(21, 60);
        system.AddBid(10, 31, 504);
        system.RemoveBid(10, 31);
        system.UpdateBid(4, 62, 725);
        system.AddBid(44, 27, 2675);
        system.UpdateBid(44, 27, 874);
        system.AddBid(1, 65, 2539);
        system.UpdateBid(44, 27, 1089);
        system.UpdateBid(44, 27, 1601);
        system.AddBid(28, 18, 2663);
        system.UpdateBid(19, 49, 796);
        system.RemoveBid(1, 65);
        system.AddBid(12, 49, 2286);
        Assert.Equal(28, system.GetHighestBidder(18));
        Assert.Equal(12, system.GetHighestBidder(49));
        system.RemoveBid(28, 18);
        system.RemoveBid(19, 49);
        system.RemoveBid(4, 62);
        system.RemoveBid(12, 49);
        system.UpdateBid(44, 27, 102);
        system.RemoveBid(44, 27);
        Assert.Equal(-1, system.GetHighestBidder(3));
        system.AddBid(68, 53, 3);
        system.RemoveBid(68, 53);
        Assert.Equal(-1, system.GetHighestBidder(56));
        system.AddBid(17, 4, 2423);
        system.RemoveBid(17, 4);
        system.AddBid(51, 62, 1512);
    }
}
