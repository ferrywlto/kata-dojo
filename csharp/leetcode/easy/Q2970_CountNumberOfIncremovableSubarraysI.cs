public class Q2970_CountNumberOfIncremovableSubarraysI
{
    public int IncremovableSubarrayCount(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4], 10},
        {[6,5,7,8], 7},
        {[8,7,6,6], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = IncremovableSubarrayCount(input);
        Assert.Equal(expected, actual);
    }
}