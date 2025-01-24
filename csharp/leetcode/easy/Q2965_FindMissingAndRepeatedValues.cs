public class Q2965_FindMissingAndRepeatedValues
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        return [];
    }
    public static TheoryData<int[][], int[]> TestData => new()
    {
        {[[1,3],[2,2]], [2,4]},
        {[[9,1,7],[8,9,2],[3,4,6]], [9,5]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[] expected)
    {
        var actual = FindMissingAndRepeatedValues(input);
        Assert.Equal(expected, actual);
    }
}