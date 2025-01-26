public class Q3000_MaxAreaOfLongestDiagonalRectangle
{
    public int AreaOfMaxDiagonal(int[][] dimensions) 
    {
        return 0;   
    }    
    public static TheoryData<int[][], int> TestData => new ()
    {
        {[[9,3],[8,6]], 48},
        {[[3,4],[4,3]], 12},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = AreaOfMaxDiagonal(input);
        Assert.Equal(expected, actual);
    }
}