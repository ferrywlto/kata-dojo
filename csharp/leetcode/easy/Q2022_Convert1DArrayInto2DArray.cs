public class Q2022_Convert1DArrayInto2DArray
{
    // TC: O(n), n scale with length of original
    // SC: O(n), the result will be the same space used as original
    public int[][] Construct2DArray(int[] original, int m, int n)
    {
        if (m * n != original.Length) return [];

        var result = new int[m][];
        for (var i = 0; i < m; i++)
        {
            result[i] = new int[n];
            for (var j = 0; j < n; j++)
            {
                result[i][j] = original[i * n + j];
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,3,4}, 2, 2, new int[][] {[1,2],[3,4]}],
        [new int[] {1,2,3}, 1, 3, new int[][] {[1,2,3]}],
        [new int[] {1,2}, 1, 1, Array.Empty<int[]>()],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int m, int n, int[][] expected)
    {
        var actual = Construct2DArray(input, m, n);
        Assert.Equal(expected, actual);
    }
}