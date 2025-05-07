public class Q807_MaxIncreaseToKeepCitySkyline
{
    // TC: O(n^2), n scale with rows in grid, it have to iterate all elements twice
    // SC: O(n), only need to store the skylines
    public int MaxIncreaseKeepingSkyline(int[][] grid)
    {
        var len = grid.Length;
        var skylineCol = new int[len];
        var skylineRow = new int[len];

        for (var row = 0; row < len; row++)
        {
            for (var col = 0; col < len; col++)
            {
                var g = grid[row][col];
                if (g > skylineCol[col])
                    skylineCol[col] = g;

                if (g > skylineRow[row])
                    skylineRow[row] = g;
            }
        }

        var result = 0;
        for (var row = 0; row < len; row++)
        {
            for (var col = 0; col < len; col++)
            {
                var g = grid[row][col];
                var maxHeight = Math.Min(skylineCol[col], skylineRow[row]);
                if (maxHeight > g)
                    result += maxHeight - g;
            }
        }
        return result;
    }
    
    public static TheoryData<int[][], int> TestData => new()
    {
        {[
            [3,0,8,4],
            [2,4,5,7],
            [9,2,6,3],
            [0,3,1,0]
        ], 35},
        // 1. the skyline is the same from N/S and W/E
        // W 8,7,9,3
        // N 9,4,8,7
        // E 8,7,9,3
        // S 9,4,8,7

        // 2. the max height is the min between the skyline intersect
        //   9 4 8 7
        // 8 8 4 8 7
        // 7 7 4 7 7
        // 9 9 4 8 7
        // 3 3 3 3 3

        // 3. it is verified the min of intersect equals to output from example
        // 8,4,8,7
        // 7,4,7,7
        // 9,4,8,7
        // 3,3,3,3
        {[[0,0,0],[0,0,0],[0,0,0]], 0}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = MaxIncreaseKeepingSkyline(input);
        Assert.Equal(expected, actual);
    }
}