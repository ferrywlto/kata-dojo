public class Q3033_ModfiyTheMatrix
{
    // TC: O(n + m), n scale with total number of items in matrix, m scale with the number of -1 in matrix
    // SC: O(c + m), c scale with columns of matrix
    public int[][] ModifiedMatrix(int[][] matrix)
    {
        var colMaxes = new int[matrix[0].Length];
        var negOneIdxes = new List<(int, int)>();
        for (var col = 0; col < matrix[0].Length; col++)
        {
            var max = matrix[0][col];
            for (var row = 0; row < matrix.Length; row++)
            {
                var current = matrix[row][col];
                if (current == -1)
                {
                    negOneIdxes.Add((row, col));
                }
                else if (current > max)
                {
                    max = current;
                }
            }
            colMaxes[col] = max;
        }
        foreach (var neg in negOneIdxes)
        {
            matrix[neg.Item1][neg.Item2] = colMaxes[neg.Item2];
        }
        return matrix;
    }
    public static TheoryData<int[][], int[][]> TestData => new()
    {
        {
            [
                [1,2,-1],
                [4,-1,6],
                [7,8,9]
            ],
            [
                [1,2,9],
                [4,8,6],
                [7,8,9]
            ]
        },
        {
            [
                [3,-1],
                [5,2]
            ],
            [
                [3,2],
                [5,2]
            ]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[][] expected)
    {
        var actual = ModifiedMatrix(input);
        Assert.Equal(expected, actual);
    }
}