public class Q3668_RestoreFinishingOrder
{
    // TC: O(n+m), n scale with length of order, m scale with length of friends
    // SC: O(n)
    public int[] RecoverOrder(int[] order, int[] friends)
    {
        var isOrderPositionOurFriend = new bool[order.Length+1];
        foreach (var f in friends)
        {
            isOrderPositionOurFriend[f] = true;
        }
        
        var idx=0;
        foreach (var o in order)
        {
            if (isOrderPositionOurFriend[o])
            {
                friends[idx++] = o;
            }
        }

        return friends;
    }    

    public static TheoryData<int[], int[] ,int[]> TestData => new()
    {
        {[3,1,2,5,4], [1,3,4], [3,1,4]},
        {[1,4,5,3,2], [2,5], [5,2]},
    };
        
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] order, int[] friends, int[] expected)
    {
        var actual = RecoverOrder(order, friends);
        Assert.Equal(expected, actual);
    }
}
