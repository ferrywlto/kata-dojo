public class Q3940_LimitOccurenceInSortedArray
{
    // TC: O(n), n scale with nums.Length
    // SC: O(n), O(1) if not counting the result
    public int[] LimitOccurrences(int[] nums, int k)
    {
        if (nums.Length <= k) return nums;

        Span<int> freq = stackalloc int[101];
        var result = new List<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (freq[nums[i]]++ < k)
                result.Add(nums[i]);
        }
        return result.ToArray();
    }

    public static TheoryData<int[], int, int[]> TestData => new()
    {
        { [1, 1, 1, 2, 2, 3], 2, [1, 1, 2, 2, 3] },
        { [1, 2, 3], 1, [1, 2, 3] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int[] expected)
    {
        var actual = LimitOccurrences(input, k);
        Assert.Equal(expected, actual);
    }
}
