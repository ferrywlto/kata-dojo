public class Q3318_FindXSumOfAllKLongSubarraysI
{
    public int[] FindXSum(int[] nums, int k, int x)
    {
        return [];
    }
    public static TheoryData<int[], int, int, int[]> TestData => new()
    {
        {[1,1,2,2,3,4,2,3], 6, 2, [6,10,12]},
        {[3,8,7,8,7,5], 2, 2, [11,15,15,15,12]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int x, int[] expected)
    {
        var actual = FindXSum(input, k, x);
        Assert.Equal(expected, actual);
    }
}