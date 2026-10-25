public class Q4084_LastVisitedCellInADirectionalGrid
{
    public int[] LastVisitedCell(char[][] grid)
    {
        return [];
    }

    public static TheoryData<char[][], int[]> TestData => new()
    {
        { [['R', 'D'], ['U', 'L']], [1, 0] },
        { [['R', 'R', 'R']], [0,2]},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(char[][] input, int[] expected)
    {
        var actual = LastVisitedCell(input);
        Assert.Equal(expected, actual);
    }
}
