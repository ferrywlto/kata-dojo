public class Q3814_DesignAuctionSystem
{
    private class AuctionSystem {

        public AuctionSystem() {
            
        }
        
        public void AddBid(int userId, int itemId, int bidAmount) {
            
        }
        
        public void UpdateBid(int userId, int itemId, int newAmount) {
            
        }
        
        public void RemoveBid(int userId, int itemId) {
            
        }
        
        public int GetHighestBidder(int itemId) {
            return 0;
        }
    }
    
    [Fact]
    public void Test()
    {
        var system = new AuctionSystem();
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
}
