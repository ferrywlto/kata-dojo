public class Q3898_FindDegreeOfEachVertex
{
    // TC: O(n * m), scale with size of input
    // SC: O(n), scale with rows of input
    public int[] FindDegrees(int[][] matrix)
    {
        var result = new int[matrix.Length];
        for (var row = 0; row < matrix.Length; row++)
        {
            for (var col = 0; col < matrix[row].Length; col++)
            {
                result[row] += matrix[row][col];
            }
        }
        return result;
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
