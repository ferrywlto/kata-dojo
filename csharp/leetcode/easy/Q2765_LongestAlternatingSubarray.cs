public class Q2765_LongestAlternatingSubarray
{
    public int AlternatingSubarray(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,3,4,3,4], 4},
        {[4,5,6], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = AlternatingSubarray(input);
        Assert.Equal(expected, actual);
    }
}