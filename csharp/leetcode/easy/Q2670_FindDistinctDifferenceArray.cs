public class Q2670_FindDistinctDifferenceArray
{
    // TC: O(n), n scale with length of nums, 2n in total
    // SC: O(n + m), n to hold the result plus m where m scale with unique numbers in nums
    public int[] DistinctDifferenceArray(int[] nums)
    {
        var suffix = new Dictionary<int, int>();
        var prefix = new HashSet<int>();
        var result = new int[nums.Length];

        foreach (var n in nums)
        {
            if (suffix.TryGetValue(n, out var val)) suffix[n] = ++val;
            else suffix.Add(n, 1);
        }

        for (var i = 0; i < nums.Length; i++)
        {
            prefix.Add(nums[i]);
            suffix[nums[i]]--;
            if (suffix[nums[i]] == 0) suffix.Remove(nums[i]);
            result[i] = prefix.Count - suffix.Count;
        }

        return result;
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[1,2,3,4,5], [-3,-1,1,3,5]},
        {[3,2,3,4,2], [-2,-1,0,2,3]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = DistinctDifferenceArray(input);
        Assert.Equal(expected, actual);
    }
}