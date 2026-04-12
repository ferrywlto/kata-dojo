public class Q3898_FindDegreeOfEachVertex
{
    public int[] FindDegrees(int[][] matrix)
    {
        return [];
    }

    public static TheoryData<int[][], int[]> TestData => new()
    {
        { [[0, 1, 1], [1, 0, 1], [1, 1, 0]], [2, 2, 2] },
        { [[0, 1, 0], [1, 0, 0], [0, 0, 0]], [1, 1, 0] },
        { [[0]], [0] }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[] expected)
    {
        var actual = FindDegrees(input);
        Assert.Equal(expected, actual);
    }
}
