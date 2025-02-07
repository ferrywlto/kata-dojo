public class Q3142_CheckIfGridSatisfiesConditions
{
    public bool SatisfiesConditions(int[][] grid)
    {
        return false;
    }
    public static TheoryData<int[][], bool> TestData => new()
    {
        {[[1,0,2],[1,0,2]], true},
        {[[1,1,1],[0,0,0]], false},
        {[[1],[2],[3]], false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, bool expected)
    {
        var actual = SatisfiesConditions(input);
        Assert.Equal(expected, actual);
    }
}