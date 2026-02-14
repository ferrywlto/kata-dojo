public class Q2500_DeleteGreatestValueInEachRow
{
    // TC: O(n log n), n scale with m x n items in grid. n log n from Array.Sort, plus m x n times to check the largest element per column
    // SC: O(1), space used does not scale with input
    public int DeleteGreatestValue(int[][] grid)
    {
        foreach (var row in grid)
        {
            Array.Sort(row);
        }

        var result = new int[grid[0].Length];
        for (var col = 0; col < grid[0].Length; col++)
        {
            var colMax = int.MinValue;
            for (var row = 0; row < grid.Length; row++)
            {
                var cell = grid[row][^(col + 1)];
                if (cell > colMax)
                {
                    colMax = cell;
                    result[col] = colMax;
                }
            }
        }
        return result.Sum();
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][]
            {
                [1,2,4],[3,3,1]
            }, 8
        ],
        [
            new int[][]
            {
                [10]
            }, 10
        ]
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = DeleteGreatestValue(input);
        Assert.Equal(expected, actual);
    }
}
