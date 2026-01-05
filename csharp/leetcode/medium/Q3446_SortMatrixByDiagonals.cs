public class Q3446_SortMatrixByDiagonals
{
    public int[][] SortMatrix(int[][] grid)
    {
        
        return [];
    }
    public static TheoryData<int[][], int[][]> TestData => new()
    {
        {
            [[1,7,3],[9,8,2],[4,5,6]],
            [[8,2,3],[9,6,7],[4,5,1]]
        },
        {
            [[0,1],[1,2]],[[2,1],[1,0]]
        },
        {
            [[1]], [[1]]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[][] expected)
    {
        var actual = SortMatrix(input);
        Assert.Equal(expected, actual);
    }
}
