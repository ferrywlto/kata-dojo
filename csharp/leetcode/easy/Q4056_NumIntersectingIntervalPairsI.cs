public class Q4056_NumIntersectingIntervalPairsI
{
    // TC: O(n^2)
    // SC: O(1)
    public int CountIntersectingIntervals(int[][] intervals)
    {
        var result = 0;
        for (var i = 0; i < intervals.Length - 1; i++)
        {
            for (var j = i + 1; j < intervals.Length; j++)
            {
                if (Math.Max(intervals[i][0], intervals[j][0]) <= Math.Min(intervals[i][1], intervals[j][1]))
                    result++;
            }
        }
        return result;
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
