public class Q1828_QueryiesNumPointsInsideCircle
{
    public int[] CountPoints(int[][] points, int[][] queries)
    {
        return [];
    }
    public static TheoryData<int[][], int[][], int[]> TestData => new()
    {
        {
            [[1,3],[3,3],[5,3],[2,2]],
            [[2,3,1],[4,3,1],[1,1,2]],
            [3,2,2]
        },
        {
            [[1,1],[2,2],[3,3],[4,4],[5,5]],
            [[1,2,2],[2,2,2],[4,3,2],[4,3,3]],
            [2,3,2,4]
        },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] p, int[][] q, int[] expected)
    {
        var actual = CountPoints(p, q);
        Assert.Equal(expected, actual);
    }
}