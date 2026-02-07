public class Q3829_DesignRideSharingSystem
{
    public class RideSharingSystem {

        public RideSharingSystem() {
            
        }
        
        public void AddRider(int riderId) {
            
        }
        
        public void AddDriver(int driverId) {
            
        }
        
        public int[] MatchDriverWithRider() {
            return [];
        }
        
        public void CancelRider(int riderId) {
            
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
        var sys = new RideSharingSystem(); // Initializes the system
        sys.AddRider(8); // rider 8 joins the queue
        sys.AddDriver(8); // driver 8 joins the queue
        sys.AddDriver(6); // driver 6 joins the queue
        sys.MatchDriverWithRider(); // returns [8, 8]
        Assert.Equal([8, 8], sys.MatchDriverWithRider());

        sys.AddRider(2); // rider 2 joins the queue
        sys.CancelRider(2); // rider 2 cancels
        sys.MatchDriverWithRider(); // returns [-1, -1]
        Assert.Equal([-1, -1], sys.MatchDriverWithRider());
    }
}
