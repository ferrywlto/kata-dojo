public class Q3919_MinCostToMoveBetweenIndices
{
    public int[] MinCost(int[] nums, int[][] queries)
    {
        return [];
    }

    public static TheoryData<int[], int[][], int[]> TestData => new()
    {
        {
            [-5, -2, 3], [[0, 2], [2, 0], [1, 2]], [6, 2, 5]
        },
        {
            [0, 2, 3, 9], [[3, 0], [1, 2], [2, 0]], [4, 1, 3]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[][] queries, int[] expected)
    {
        var actual = MinCost(input, queries);
        Assert.Equal(expected, actual);
    }
}
