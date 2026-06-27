public class Q3567_MinAbsDiffInSlidingSubmatrix
{
    public int[][] MinAbsDiff(int[][] grid, int k)
    {
        return [];
    }

    public static TheoryData<int[][], int, int[][]> TestData => new()
    {
        { [[1, 8], [3, -2]], 2, [[2]] },
        { [[3, -1]], 1, [[0, 0]] },
        { [[1, -2, 3], [2, 3, 5]], 2, [[1, 2]] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int k, int[][] expected)
    {
        var actual = MinAbsDiff(input, k);
        Assert.Equal(expected, actual);
    }
}
