public class Q1072_FlipColumnsForMaxNumberOfEqualRows
{
    public int MaxEqualRowsAfterFlips(int[][] matrix)
    {
        return 0;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {
            [
                [0,1],
                [1,1]
            ], 1
        },
        {
            [
                [0,1],
                [1,0]
            ], 2
        },
        {
            [
                [0,0,0],
                [0,0,1],
                [1,1,0]
            ], 2
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = MaxEqualRowsAfterFlips(input);
        Assert.Equal(expected, actual);
    }
}
