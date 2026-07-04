public class Q3978_UniqueMiddleElement
{
    // TC: O(n), n scale with length of nums
    // SC: O(1)
    public bool IsMiddleElementUnique(int[] nums)
    {
        if (nums.Length == 1) return true;

        Span<int> freq = stackalloc int[101];
        foreach (var n in nums)
            freq[n]++;

        // nums.Length must be odd, middle = ?
        // 1 => 1
        // 3 => 1
        // 5 => 2
        var middleIdx = nums.Length / 2;
        var middleNum = nums[middleIdx];
        return freq[middleNum] == 1;
    }

    public static TheoryData<int[], bool> TestData => new()
    {
        { [1, 2, 3], true },
        { [1, 2, 2], false },
        { [13], true },
        { [9,78,45], true},
        { [84,75,84], true},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = IsMiddleElementUnique(input);
        Assert.Equal(expected, actual);
    }
}
