class Q1260_Shift2DGrid
{
    // TC: O(n), n is total elements in grid * k times
    // SC: O(n) if count the conversion needed for the result type, otherwise O(1)
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        int lastRowEnd = int.MinValue;
        var count = 0;
        while (count < k)
        {
            for (var i = 0; i < grid.Length; i++)
            {
                var currentRowLength = grid[i].Length - 1;
                var currentRowEnd = grid[i][currentRowLength];
                for (var j = currentRowLength; j > 0; j--)
                {
                    grid[i][j] = grid[i][j - 1];
                }
                grid[i][0] = lastRowEnd;
                lastRowEnd = currentRowEnd;
            }
            grid[0][0] = lastRowEnd;
            count++;
        }
        return grid.Select(x => (IList<int>)[.. x]).ToList();
    }
}
class Q1260_Shift2DGridTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [1,2,3],
                [4,5,6],
                [7,8,9]
            }, 1,
            new List<List<int>>
            {
                new() { 9, 1, 2 },
                new() { 3, 4, 5 },
                new() { 6, 7, 8 }
            }
        ],
        [
            new int[][]
            {
                [3,8,1,9],
                [19,7,2,5],
                [4,6,11,10],
                [12,0,21,13]
            }, 4,
            new List<List<int>>
            {
                new() { 12, 0, 21, 13 },
                new() { 3, 8, 1, 9 },
                new() { 19, 7, 2, 5 },
                new() { 4, 6, 11, 10 },
            }
        ],
        [
            new int[][]
            {
                [1,2,3],
                [4,5,6],
                [7,8,9]
            }, 9,
            new List<List<int>>
            {
                new() { 1, 2, 3 },
                new() { 4, 5, 6 },
                new() { 7, 8, 9 },
            }
        ],
    ];
}
public class Q1260_Shift2DGridTests
{
    [Theory]
    [ClassData(typeof(Q1260_Shift2DGridTestData))]
    public void OfficialTestCases(int[][] input, int times, List<List<int>> expected)
    {
        var sut = new Q1260_Shift2DGrid();
        var actual = sut.ShiftGrid(input, times);
        Assert.Equal(expected, actual);
    }
}
