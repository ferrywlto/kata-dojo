public class Q4056_NumIntersectingIntervalPairsI
{
    public int CountIntersectingIntervals(int[][] intervals)
    {
        return 0;
    }

    public static TheoryData<int[][], int> TestData => new()
    {
        { [[1, 2], [2, 3], [3, 4]], 2 },
        { [[1, 5], [2, 4], [3, 6]], 3 },
        { [[1, 2], [3, 4], [5, 6]], 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = CountIntersectingIntervals(input);
        Assert.Equal(expected, actual);
    }
}
