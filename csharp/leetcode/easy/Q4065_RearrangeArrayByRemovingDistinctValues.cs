public class Q4065_RearrangeArrayByRemovingDistinctValues
{
    // TC: O(m * n), m scale with the max frequency
    // SC: O(1)
    public int[] RearrangeArray(int[] nums)
    {
        Span<int> freq = stackalloc int[101];
        int maxCount = int.MinValue;
        foreach (var n in nums)
        {
            freq[n]++;
            if (freq[n] > maxCount) maxCount = freq[n];
        }

        var idx = 0;
        while (maxCount > 0)
        {
            for (var i = 1; i < 101; i++)
            {
                if (freq[i] == 0) continue;

                nums[idx++] = i;
                freq[i]--;
            }

            maxCount--;
        }

        return nums;
    }

    public static TheoryData<int[], int[]> TestData => new()
    {
        { [3, 1, 3, 2, 1, 3], [1, 2, 3, 1, 3, 3] },
        { [7, 7, 4, 4, 4], [4, 7, 4, 7, 4] }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = RearrangeArray(input);
        Assert.Equal(expected, actual);
    }
}
