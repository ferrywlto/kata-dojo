public class Q2760_LongestEvenOddSubarrayWithThreshold
{
    public int LongestAlternatingSubarray(int[] nums, int threshold)
    {
        return 0;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[3,2,5,4], 5, 3},
        {[1,2], 2, 1},
        {[2,3,4,5], 4, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int threshold, int expected)
    {
        var actual = LongestAlternatingSubarray(input, threshold);
        Assert.Equal(expected, actual);
    }
}