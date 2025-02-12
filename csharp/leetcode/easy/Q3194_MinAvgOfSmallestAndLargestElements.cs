public class Q3194_MinAvgOfSmallestAndLargestElements
{
    public double MinimumAverage(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], double> TestData => new()
    {
        {[7,8,3,4,15,13,4,1], 5.5},
        {[1,9,8,3,10,5], 5.5},
        {[1,2,3,7,8,9], 5.0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, double expected)
    {
        var actual = MinimumAverage(input);
        Assert.Equal(expected, actual);
    }
}