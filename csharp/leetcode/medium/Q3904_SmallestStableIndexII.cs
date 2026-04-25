public class Q3904_SmallestStableIndexII
{
    // This is the same question of Q3903 with constraints nums.Length from 100 to 10^5, the solution is the same.
    // TC: O(n), n scale with nums.Length
    // SC: O(n)
    public int FirstStableIndex(int[] nums, int k)
    {
        var len = nums.Length;

        Span<int> minTrack = stackalloc int[len];

        minTrack[^1] = nums[^1];

        var max = int.MinValue;
        var min = minTrack[^1];

        for (var i = len - 2; i >= 0; i--)
        {
            if (nums[i] < min) min = nums[i];
            minTrack[i] = min;
        }

        for (var i = 0; i < len; i++)
        {
            if (nums[i] > max) max = nums[i];

            if (max - minTrack[i] <= k) return i;
        }

        return -1;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        { [5, 0, 1, 4], 3, 3 }, { [3, 2, 1], 1, -1 }, { [0], 0, 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = FirstStableIndex(input, k);
        Assert.Equal(expected, actual);
    }
}
