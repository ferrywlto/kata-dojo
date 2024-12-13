public class Q2639_FindWidthOfColumnsOfGrid
{
    // TC: O(m * n), equals to total element counts in grid
    // SC: O(n), m scale with cols in grid to hold the result
    public int[] FindColumnWidth(int[][] grid)
    {
        var result = new int[grid[0].Length];
        for (var i = 0; i < grid[0].Length; i++)
        {
            var colMax = int.MinValue;
            for (var j = 0; j < grid.Length; j++)
            {
                var len = grid[j][i].ToString().Length;
                if (len > colMax) colMax = len;
            }
            result[i] = colMax;
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][] { [1], [22], [333]},
            new int[] {3}
        ],
        [
            new int[][] {[-15,1,3],[15,7,12],[5,6,-2]},
            new int[] {3,1,2}
        ]
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[] expected)
    {
        var actual = FindColumnWidth(input);
        Assert.Equal(expected, actual);
    }
}