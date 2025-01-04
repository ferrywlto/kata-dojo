public class Q2815_MaxPairSumInArray
{
    public int MaxSum(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[112,131,411], -1},
        {[2536,1613,3366,162], 5902},
        {[51,71,17,24,42], 88},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxSum(input);
        Assert.Equal(expected, actual);
    }
}