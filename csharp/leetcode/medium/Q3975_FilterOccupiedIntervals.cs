public class Q3975_FilterOccupiedIntervals
{
    public IList<IList<int>> FilterOccupiedIntervals(int[][] occupiedIntervals, int freeStart, int freeEnd)
    {
        return [];
    }

    public static TheoryData<int[][], int, int, List<List<int>>> TestData => new()
    {
        {
            [[2, 6], [4, 8], [10, 10], [10, 12], [14, 16]], 7, 11, [[2, 6], [12, 12], [14, 16]]
        },
        {
            [[1, 5], [2, 3]], 3, 8, [[1, 2]]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int start, int end, List<List<int>> expected)
    {
        var actual = FilterOccupiedIntervals(input, start, end);
        Assert.Equal(expected, actual);
    }
}
