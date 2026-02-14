class Q1380_LuckyNumberInMatrix
{
    // TC: O(m*n), it has to iterate all elements to find both the row min and col max
    // SC: O(m+n), number of rows + number of cols
    public IList<int> LuckyNumbers(int[][] matrix)
    {
        var rowMins = new HashSet<int>();
        var colMaxs = new HashSet<int>();

        for (var i = 0; i < matrix.Length; i++)
        {
            var row = matrix[i];
            var min = row[0];
            for (var j = 1; j < row.Length; j++)
            {
                if (row[j] < min) min = row[j];
            }
            rowMins.Add(min);
        }
        for (var i = 0; i < matrix[0].Length; i++)
        {
            var max = matrix[0][i];
            for (var j = 1; j < matrix.Length; j++)
            {
                if (matrix[j][i] > max) max = matrix[j][i];
            }
            colMaxs.Add(max);
        }
        var result = rowMins.Intersect(colMaxs);
        return result.ToList();
    }
}
class Q1380_LuckyNumberInMatrixTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][] {
                [3,7,8],
                [9,11,13],
                [15,16,17]
            },
            new int[] {15}
        ],
        [
            new int[][] {
                [1,10,4,2],
                [9,3,8,7],
                [15,16,17,12]
            },
            new int[] {12}
        ],
        [
            new int[][] {
                [7,8],
                [1,2]
            },
            new int[] {7}
        ],
        [
            new int[][] { [1] },
            new int[] {1}
        ]
    ];
}
public class Q1380_LuckyNumberInMatrixTests
{
    [Theory]
    [ClassData(typeof(Q1380_LuckyNumberInMatrixTestData))]
    public void OfficialTestCases(int[][] input, int[] expected)
    {
        var sut = new Q1380_LuckyNumberInMatrix();
        var actual = sut.LuckyNumbers(input);
        Assert.Equal(expected, actual);
    }
}
