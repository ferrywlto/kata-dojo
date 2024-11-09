using System.Text;

public class Q2373_LargestLocalValuesInMatrix
{
    // TC: O(n^2), n scale with length of grid, for each element it run FindLocalMax once which is O(1)
    // SC: O(1), space used does not scale with input if not count the result array, O(n^2) otherwise 
    public int[][] LargestLocal(int[][] grid)
    {
        var n = grid.Length;
        var result = new int[n - 2][];
        for (var k = 0; k < result.Length; k++) result[k] = new int[n - 2];

        for (var i = 0; i < n - 2; i++)
        {
            for (var j = 0; j < n - 2; j++)
            {
                result[i][j] = FindLocalMax(grid, i, j);
            }
        }
        return result;
    }
    public int FindLocalMax(int[][] grid, int row, int col)
    {
        var max = 0;
        for (var i = row; i < row + 3; i++)
        {
            for (var j = col; j < col + 3; j++)
            {
                if (grid[i][j] > max) max = grid[i][j];
            }
        }
        return max;
    }

    public static List<object[]> TestData =>
    [
        [
            new int[][]
            {
                [9,9,8,1],
                [5,6,2,6],
                [8,2,6,4],
                [6,2,2,2],
            },
            new int[][]
            {
                [9,9],
                [8,6],
            }
        ],
        [
            new int[][]
            {
                [1,1,1,1,1],
                [1,1,1,1,1],
                [1,1,2,1,1],
                [1,1,1,1,1],
                [1,1,1,1,1],
            },
            new int[][]
            {
                [2,2,2],
                [2,2,2],
                [2,2,2],
            },
        ],
        [
            new int[][]
            {
                [1,1,1],
                [1,1,1],
                [1,1,2],
            },
            new int[][]
            {
                [2],
            },
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[][] expected)
    {
        var actual = LargestLocal(input);
        Assert.Equal(expected, actual);
    }
}