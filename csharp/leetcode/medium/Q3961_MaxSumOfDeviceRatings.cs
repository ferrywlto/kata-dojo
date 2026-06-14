public class Q3961_MaxSumOfDeviceRatings
{
    // TC: O(n log n) because of many Array.Sort()
    // SC: O(1) all sorting are in-place
    public long MaxRatings(int[][] units)
    {
        if (units.Length == 1)
            return units[0].Min();

        var globalSmallest = int.MaxValue;
        var smallestSecond = int.MaxValue;
        long result = 0;
        // get max sum of min from each array
        // each array can only move 0 to 1 item to other array once

        // find the global smallest device, then each other device throw the smallest (1st item after sort) unit to that device if the device has more than 1 item
        // This makes all other device rating increase while doesn't change the rating of global smallest rating device
        // Since every array can move the smallest item out, thus the 2nd item matters than the 1st. Therefore sort by second item.
        foreach (var t in units)
        {
            Array.Sort(t);
            if (t[0] < globalSmallest) globalSmallest = t[0];
            if (t.Length > 1)
            {
                if (t[1] < smallestSecond) smallestSecond = t[1];
                result += t[1];
            }
            else
            {
                result += t[0];
            }
        }

        // Means all devices has only single item
        if (smallestSecond == int.MaxValue) return result;

        result -= smallestSecond;
        result += globalSmallest;
        return result;
    }

    public static TheoryData<int[][], long> TestData => new()
    {
        { [[1, 3], [2, 2]], 4 },
        { [[1, 2, 3], [4, 5, 6]], 6 },
        { [[5, 5, 5], [1, 1, 1]], 6 },
        { [[5],[5],[1],[4],[4]], 19 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, long expected)
    {
        var actual = MaxRatings(input);
        Assert.Equal(expected, actual);
    }
}
