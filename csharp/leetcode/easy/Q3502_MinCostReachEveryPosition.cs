public class Q3502_MinCostReachEveryPosition
{
    public int[] MinCosts(int[] cost)
    {
        return [];
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