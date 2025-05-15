public class Q1829_MaxXorForEachQuery
{
    public int[] GetMaximumXor(int[] nums, int maximumBit)
    {
        return [];
    }
    public static TheoryData<int[], int, int[]> TestData => new()
    {
        {[0,1,1,3], 2, [0,3,2,3]},
        {[2,3,4,7], 3, [5,2,6,5]},
        {[0,1,2,2,5,7], 3, [4,3,6,4,6,7]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int[] expected)
    {
        var actual = GetMaximumXor(input, k);
        Assert.Equal(expected, actual);
    }
}