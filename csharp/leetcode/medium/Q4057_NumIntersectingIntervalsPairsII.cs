public class Q4057_NumIntersectingIntervalPairsII
{
    private class IntervalComparer : IComparer<int[]>
    {
        public int Compare(int[]? x, int[]? y)
        {
            if (x?[0] > y?[1]) return 1;
            if (x?[1] < y?[1]) return -1;
            return 0;
        }
    }
    // TC: O(n^2)
    // SC: O(1)
    public int CountIntersectingIntervals(int[][] intervals)
    {
        // Sort start then end
        Array.Sort(intervals, (a, b) =>
        {
            if (a[0] > b[0]) return 1;
            if (a[0] < b[0]) return -1;
            if (a[1] > b[1]) return 1;
            if (a[1] < b[1]) return -1;
            return 0;
        });

        var result = 0;
        for (var i = 0; i < intervals.Length - 1; i++)
        {
            var searchResult = Array.BinarySearch(intervals, 0, intervals.Length - i, intervals[i], new IntervalComparer());
            if (searchResult != -1) result += searchResult;
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
