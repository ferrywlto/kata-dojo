public class Q2670_FindDistinctDifferenceArray
{
    public int[] DistinctDifferenceArray(int[] nums)
    {
        return [];
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[1,2,3,4,5], [-3,-1,1,3,5]},
        {[3,2,3,4,2], [-2,-1,0,2,3]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = DistinctDifferenceArray(input);
        Assert.Equal(expected, actual);
    }
}