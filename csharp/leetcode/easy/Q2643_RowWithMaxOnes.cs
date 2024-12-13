public class Q2643_RowWithMaxOnes
{
    public int[] RowAndMaximumOnes(int[][] mat)
    {
        return [];
    }
    public static TheoryData<int[][], int[]> TestData => new()
    {
        {new int[][] {[0,1],[1,0]}, new int[] {0,1}},
        {new int[][] {[0,0,0],[0,1,1]}, new int[] {1,2}},
        {new int[][] {[0,0],[1,1],[0,0]}, new int[] {1,2}},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[] expected)
    {
        var actual = RowAndMaximumOnes(input);
        Assert.Equal(expected, actual);
    }
}