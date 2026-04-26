public class Q3905_MultiSourceFloodFill
{
    public int[][] ColorGrid(int n, int m, int[][] sources)
    {
        return [];
    }

    public static TheoryData<int, int, int[][], int[][]> TestData => new()
    {
        {
            3, 3,
            [[0, 0, 1], [2, 2, 2]],
            [[1, 1, 2], [1, 2, 2], [2, 2, 2]]
        },
        {
            3,3,
            [[0,1,3],[1,1,5]],
            [[3,3,3],[5,5,5],[5,5,5]]
        },
        {
            2,2,
            [[1,1,5]],
            [[5,5],[5,5]]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int m, int n, int[][] input, int[][] expected)
    {
        var actual = ColorGrid(m, n, input);
        Assert.Equal(expected, actual);
    }
}
