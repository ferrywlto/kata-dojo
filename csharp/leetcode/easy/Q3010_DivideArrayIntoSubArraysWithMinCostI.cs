public class Q3010_DivideArrayIntoSubArraysWithMinCostI
{
    public int MinimumCost(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,12], 6},
        {[5,4,3], 12},
        {[10,3,1,1], 12},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumCost(input);
        Assert.Equal(expected, actual);
    }
}