public class Q3105_LongestStrictlyIncreasingOrStrictlyDecreasingSubarray
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,4,3,3,2], 2},
        {[3,3,3,3], 1},
        {[3,2,1], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = LongestMonotonicSubarray(input);
        Assert.Equal(expected, actual);
    }
}
