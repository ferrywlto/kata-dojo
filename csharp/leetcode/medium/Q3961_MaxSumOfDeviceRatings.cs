public class Q3961_MaxSumOfDeviceRatings(ITestOutputHelper output)
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
            // The improvement is here, from O(n log n) to O(n), we don't need to sort as we only want to know the min two numbers.
            var mins = Min2(t);

            output.WriteLine($"[{string.Join(',', mins)}]");
            if (mins[0] < globalSmallest) globalSmallest = mins[0];
            if (mins[1] != int.MaxValue)
            {
                if (mins[1] < smallestSecond) smallestSecond = mins[1];
                result += mins[1];
            }
            else
            {
                result += mins[0];
            }
        }

        // Means all devices has only single item
        if (smallestSecond == int.MaxValue) return result;

        result -= smallestSecond;
        result += globalSmallest;
        return result;
    }

    private int[] Min2(int[] input)
    {
        var min1 = int.MaxValue;
        var min2 = int.MaxValue;

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] < min1)
            {
                min2 = min1;
                min1 = input[i];
            }
            else if (input[i] < min2)
            {
                min2 = input[i];
            }
        }

        return [min1, min2];
    }
    public static TheoryData<int[][], long> TestData => new()
    {
        { [[1, 3], [2, 2]], 4 },
        { [[1, 2, 3], [4, 5, 6]], 6 },
        { [[5, 5, 5], [1, 1, 1]], 6 },
        { [[5],[5],[1],[4],[4]], 19 },
        { [[2,3],[4,1],[4,1],[2,1]], 12},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, long expected)
    {
        var actual = MaxRatings(input);
        Assert.Equal(expected, actual);
    }
}
