class Q766_ToeplitzMatrix
{
    // TC: O(n*m)
    // SC: O(1)
    public bool IsToeplitzMatrix(int[][] matrix)
    {
        for (var row = 1; row < matrix.Length; row++)
        {
            for (var col = 1; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] != matrix[row - 1][col - 1]) return false;
            }
        }
        return true;
    }
}

class Q766_ToeplitzMatrixTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [1, 2, 3, 4],
                [5, 1, 2, 3],
                [9, 5, 1, 2],
            },
            true
        ],
        [
            new int[][]
            {
                [1, 2],
                [2, 2],
            },
            false
        ]
    ];
}

public class Q766_ToeplitzMatrixTests
{
    [Theory]
    [ClassData(typeof(Q766_ToeplitzMatrixTestData))]
    public void OfficialTestCases(int[][] input, bool expected)
    {
        var sut = new Q766_ToeplitzMatrix();
        var actual = sut.IsToeplitzMatrix(input);
        Assert.Equal(expected, actual);
    }
}
