public class Q3809_BestReachableTower
{
    public int[] BestTower(int[][] towers, int[] center, int radius)
    {
        return [];
    }

    public static TheoryData<int[][], int[], int, int[]> TestData => new()
    {
        { [[1, 2, 5], [2, 1, 7], [3, 1, 9]], [1, 1], 2, [3, 1] },
        { [[1, 3, 4], [2, 2, 4], [4, 4, 7]], [0, 0], 5, [1, 3] },
        { [[5, 6, 8], [0, 3, 5]], [1, 2], 1, [-1, -1] }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] towers, int[] center, int radius, int[] expected)
    {
        var actual = BestTower(towers, center, radius);
        Assert.Equal(expected, actual);
    }
}
