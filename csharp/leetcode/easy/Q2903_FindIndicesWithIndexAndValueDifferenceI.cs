public class Q2903_FindIndicesWithIndexAndValueDifferenceI
{
    public int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
    {
        return [];
    }
    public static TheoryData<int[], int, int, int[]> TestData => new()
    {
        {[5,1,4,1], 2, 4, [0,3]},
        {[2,1], 0, 0, [0,0]},
        {[1,2,3], 2, 4, [-1,-1]}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int idxDiff, int valDiff, int[] expected)
    {
        var actual = FindIndices(input, idxDiff, valDiff);
        Assert.Equal(expected, actual);
    }
}