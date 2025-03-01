public class Q3392_CountSubarraysOfLengthThreeWithCondition
{
    public int CountSubarrays(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,1,4,1], 1},
        {[1,1,1], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountSubarrays(input);
        Assert.Equal(expected, actual);
    }
}