public class Q2022_Convert1DArrayInto2DArray
{
    public int[][] Construct2DArray(int[] original, int m, int n)
    {
        return [];
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