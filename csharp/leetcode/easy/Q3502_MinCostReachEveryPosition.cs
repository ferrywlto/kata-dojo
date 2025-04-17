public class Q3502_MinCostReachEveryPosition
{
    // TC: O(n), n scale with length of cost
    // SC: O(1), space used does not scale with input
    public int[] MinCosts(int[] cost)
    {
        var min = int.MaxValue;
        for (var i = 0; i < cost.Length; i++)
        {
            if (cost[i] < min)
            {
                min = cost[i];
            }
            cost[i] = min;
        }
        return cost;
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[5,3,4,1,3,2], [5,3,3,1,1,1]},
        {[1,2,4,6,7], [1,1,1,1,1]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = MinCosts(input);
        Assert.Equal(expected, actual);
    }
}