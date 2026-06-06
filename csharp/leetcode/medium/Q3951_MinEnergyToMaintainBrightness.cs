public class Q3951_MinEnergyToMaintainBrightness
{
    // TC: O(n log n), due to Array.Sort, plus O(n) for the loop
    // SC: O(n), n scale with length of intervals.
    public long MinEnergy(int n, int brightness, int[][] intervals)
    {
        var numBulbsOn = (int)Math.Min(Math.Ceiling((double)brightness / 3), n);

        // For interval merging problems, we need to sort the array.
        Array.Sort(intervals, (a, b) =>
        {
            if (a[0] < b[0]) return -1;
            return 1;
        });

        var buckets = new List<int[]>(intervals.Length) { intervals[0] };
        var prevIdx = 0;

        long result = 0L;

        // Since array is sorted, if start is larger then previous.end, guarantee a new bucket.
        for (var i = 1; i < intervals.Length; i++)
        {
            var start = intervals[i][0];
            var end = intervals[i][1];

            var preEnd = buckets[prevIdx][1];
            if (start > preEnd)
            {
                // Improved time to calculate the cost immediately for previous bucket when detected a new bucket entry.
                long time = preEnd - buckets[prevIdx][0] + 1;
                result += time * numBulbsOn;

                buckets.Add(intervals[i]);
                prevIdx++;
            }
            else if (end > preEnd)
                buckets[prevIdx][1] = end;
        }

        result += (long)(buckets[prevIdx][1] - buckets[prevIdx][0] + 1) * numBulbsOn;

        return result;
    }

    public static TheoryData<int, int, int[][], long> TestData => new()
    {
        { 5, 5, [[6, 12]], 14 },
        { 2, 1, [[0, 0], [2, 2]], 2 },
        { 4, 2, [[1, 3], [2, 4]], 4 },
        { 3, 2, [[0, 0], [0, 0]], 1 },
        {
            738235, 635017,
            [
                [880012, 962435], [880012, 984965], [880012, 966345], [880012, 959020], [880012, 954813],
                [880012, 891751], [880012, 924920], [880012, 998728], [880012, 943084], [880012, 909394],
                [880012, 949521], [880012, 966713], [880012, 883519], [880012, 930005], [880012, 939543],
                [880012, 960371], [880012, 955023], [880012, 929936], [880012, 940539]
            ],
            25129183541
        },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int brightness, int[][] intervals, long expected)
    {
        var actual = MinEnergy(n, brightness, intervals);
        Assert.Equal(expected, actual);
    }
}
