public class Q3961_MaxSumOfDeviceRatings(ITestOutputHelper output)
{
    // TC: O(n log n) because of many Array.Sort()
    // SC: O(1) all sorting are in-place
    public long MaxRatings(int[][] units)
    {
        // get max sum of min from each array
        // each array can only move 0 to 1 item to other array once
        foreach (var t in units)
            Array.Sort(t);

        if (units.Length == 1) return units[0][0];

        // find the global smallest device, then each other device throw the smallest (1st item after sort) unit to that device if the device has more than 1 item
        // This makes all other device rating increase while doesn't change the rating of global smallest rating device
        var globalSmallest = int.MaxValue;
        for (var i = 0; i < units.Length; i++)
        {
            for (var j = 0; j < units[i].Length; j++)
            {
                if (units[i][j] < globalSmallest)
                    globalSmallest = units[i][j];
            }
        }

        // Since every array can move the smallest item out, thus the 2nd item matters than the 1st. Therefore sort by second item.
        Array.Sort(units, (a, b) =>
        {
            var c = a.Length > 1 ? a[1] : a[0];
            var d = b.Length > 1 ? b[1] : b[0];
            if (c > d) return 1;
            if (c < d) return -1;
            return 0;
        });

        // now global smallest rating device is units[0]
        output.WriteLine($"sort: {string.Join(Environment.NewLine, units.Select(t => string.Join(',', t)))}");

        // Handle the case that after all transfer the smallest rating device should have to global smallest rating
        long result = globalSmallest;

        for (var i = 1; i < units.Length; i++)
        {
            if(units[i].Length > 1)
            {
                result += units[i][1];
            }
            else
            {
                result += units[i][0];
            }
        }

        return result;
    }

    public static TheoryData<int[][], long> TestData => new()
    {
        { [[1, 3], [2, 2]], 4 },
        { [[1, 2, 3], [4, 5, 6]], 6 },
        { [[5, 5, 5], [1, 1, 1]], 6 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, long expected)
    {
        var actual = MaxRatings(input);
        Assert.Equal(expected, actual);
    }
}
