public class Q2946_MatrixSimilarityAfterCyclicShifts
{
    public bool AreSimilar(int[][] mat, int k)
    {
        return false;
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
