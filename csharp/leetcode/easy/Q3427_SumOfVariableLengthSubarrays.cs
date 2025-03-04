public class Q3427_SumOfVariableLengthSubarrays
{
    public int SubarraySum(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,3,1], 11},
        {[3,1,1,2], 13},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SubarraySum(input);
        Assert.Equal(expected, actual);
    }
}