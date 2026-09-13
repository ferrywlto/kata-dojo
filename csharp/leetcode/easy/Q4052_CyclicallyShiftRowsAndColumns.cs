public class Q4052_CyclicallyShiftRowsAndColumns
{
    public int[][] CyclicShift(int n, int[][] grid, int[] rowShift, int[] colShift)
    {
        return [];
    }

    public static TheoryData<int, int[][], int[], int[], int[][]> TestData => new()
    {
        {
            2, [[1, 2], [3, 4]], [1, 0], [0, 1], [[2, 4], [3, 1]]
        },
        {
            3, [[1, 2, 3], [4, 5, 6], [7, 8, 9]], [1, 2, 0], [2, 2, 1], [[7, 8, 5], [2, 3, 9], [6, 4, 1]]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] input, int[] rowShift, int[] colShift, int[][] expected)
    {
        var actual = CyclicShift(n, input, rowShift, colShift);
        Assert.Equal(expected, actual);
    }
}
