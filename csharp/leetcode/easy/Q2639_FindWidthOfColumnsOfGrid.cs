public class Q2639_FindWidthOfColumnsOfGrid
{
    public int[] FindColumnWidth(int[][] grid)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][] { [1], [22], [333]},
            new int[] {3}
        ],
        [
            new int[][] {[-15,1,3],[15,7,12],[5,6,-2]},
            new int[] {3,1,2}
        ]
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[] expected)
    {
        var actual = FindColumnWidth(input);
        Assert.Equal(expected, actual);
    }
}