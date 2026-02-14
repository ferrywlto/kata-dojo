public class Q2946_MatrixSimilarityAfterCyclicShifts
{
    // TC: O(n*m), n scale with length of mat, for each row, do the shift k times, each shift do n operations
    // SC: O(m), m scale with length of a row
    public bool AreSimilar(int[][] mat, int k)
    {
        for (var i = 0; i < mat.Length; i++)
        {
            var row = mat[i];
            if (row.Length == 1) continue;

            var clone = new int[row.Length];

            var shifts = k % row.Length;
            if (shifts == 0) continue;

            if (i % 2 == 0) LeftShift(row, clone, shifts);
            else RightShift(row, clone, shifts);

            if (!clone.SequenceEqual(row)) return false;
        }
        return true;
    }
    private void LeftShift(int[] input, int[] output, int k)
    {
        var len = input.Length;
        for (var i = 0; i < len; i++)
        {
            output[i] = input[(i + k) % len];
        }
    }
    private void RightShift(int[] input, int[] output, int k)
    {
        var len = input.Length;
        for (var i = 0; i < len; i++)
        {
            output[i] = input[(i - k + len) % len];
        }
    }
    public static TheoryData<int[][], int, bool> TestData => new()
    {
        {
            [
                [1,2,3],
                [4,5,6],
                [7,8,9],
            ], 4, false
        },
        {
            [
                [1,2,1,2],
                [5,5,5,5],
                [6,3,6,3],
            ], 2, true
        },
        {
            [
                [2,2],
                [2,2],
            ], 3, true
        },
        {
            [
                [3,10,3,10,3,10,3,10],
                [5,8,5,8,5,8,5,8],
                [3,9,3,9,3,9,3,9],
                [3,8,3,8,3,8,3,8],
                [2,3,2,3,2,3,2,3]
            ], 2, true
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int k, bool expected)
    {
        var actual = AreSimilar(input, k);
        Assert.Equal(expected, actual);
    }
}
