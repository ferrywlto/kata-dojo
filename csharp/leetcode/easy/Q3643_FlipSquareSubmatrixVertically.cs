public class Q3643_FlipSquareSubmatrixVertically
{
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
    {
        return [];
    }
    public static TheoryData<int[][], int, int, int, int[][]> TestData => new()
    {
        {
            [[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]], 1, 0, 3,
            [[1,2,3,4],[13,14,15,8],[9,10,11,12],[5,6,7,16]]
        },
        {
            [[3,4,2,3],[2,3,4,2]], 0, 2, 2,
            [[3,4,4,2],[2,3,2,3]]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int x, int y, int k, int[][] expected)
    {
        var actual = ReverseSubmatrix(input, x, y, k);
        Assert.Equal(expected, actual);
    }
}
