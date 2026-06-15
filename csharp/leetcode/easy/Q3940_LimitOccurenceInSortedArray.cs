public class Q3940_LimitOccurenceInSortedArray
{
    // TC: O(n), n scale with nums.Length
    // SC: O(n), O(1) if not counting the result
    public int[] LimitOccurrences(int[] nums, int k)
    {
        if (nums.Length <= k) return nums;

        Span<int> freq = stackalloc int[101];

        var writeIdx = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (freq[nums[i]] == k) continue;

            // can be a bit faster if we compare the last k items the same as current item to avoid counting frequencies due to the array has been already sorted. But it doesn't worth the effort.
            freq[nums[i]]++;
            nums[writeIdx] = nums[i];
            writeIdx++;
        }

        var result = new int[writeIdx];
        for (var i = 0; i < writeIdx; i++) result[i] = nums[i];

        return result;
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
