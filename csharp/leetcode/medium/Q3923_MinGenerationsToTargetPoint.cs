public class Q3923_MinGenerationsToTargetPoint
{
    public int MinGenerations(int[][] points, int[] target)
    {
        return 0;
    }

    public static TheoryData<int[][], int[], int> TestData => new()
    {
        { [[0, 0, 0], [6, 6, 6]], [3, 3, 3], 1 },
        { [[0, 0, 0], [5, 5, 5]], [1, 1, 1], 2 },
        { [[0, 0, 0], [2, 2, 2], [3, 3, 3]], [2, 2, 2], 0 },
        { [[1, 2, 3]], [5, 5, 5], -1 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] points, int[] target, int expected)
    {
        var actual = MinGenerations(points, target);
        Assert.Equal(expected, actual);
    }
}
