public class Q2133_CheckIfEveryRowAndColumnContainsAllNumbers
{
    // TC: O(n), n scale with length of matrix, iterate just single pass
    // SC: O(n), n scale with length of matrix, 2n for two hashsets
    public bool CheckValid(int[][] matrix)
    {
        var n = matrix.Length;
        var setRow = new HashSet<int>();
        var setCol = new HashSet<int>();
        for (var row = 0; row < matrix.Length; row++)
        {
            for (var col = 0; col < matrix[row].Length; col++)
            {
                setRow.Add(matrix[row][col]);
                setCol.Add(matrix[col][row]);
            }
            if (setRow.Count != n || setCol.Count != n) return false;
            setRow.Clear();
            setCol.Clear();
        }
        return true;
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][]
            {
                [1,2,3],[3,1,2],[2,3,1]
            }, true,
        ],
        [
            new int[][]
            {
                [1,1,1],[1,2,3],[1,2,3]
            }, false,
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, bool expected)
    {
        var actual = CheckValid(input);
        Assert.Equal(expected, actual);
    }
}