public class Q2923_FindChampionI
{
    // TC: O(n), n scale with total number of elements in grid
    // SC: O(1), space used does not scale with input
    public int FindChampion(int[][] grid)
    {
        var largest = 0;
        var largestIdx = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            var count = 0;
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1) count++;
            }
            if (count > largest)
            {
                largest = count;
                largestIdx = i;
            }
        }
        return largestIdx;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[0,1],[0,0]], 0},
        {[[0,0,1],[1,0,1],[0,0,0]], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = FindChampion(input);
        Assert.Equal(expected, actual);
    }
}