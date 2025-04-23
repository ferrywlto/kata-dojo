public class Q2044_CountNumOfMaxBitwiseOrSubsets
{
    public int CountMaxOrSubsets(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[3,1], 2},
        {[2,2,2], 7},
        {[3,2,1,5], 6},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountMaxOrSubsets(input);
        Assert.Equal(expected, actual);
    }
}