public class Q2913_SubarraysDistinctElementSumOfSquaresI//(ITestOutputHelper output)
{
    // TC: O(n^2), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums, worst case nums
    public int SumCounts(IList<int> nums)
    {
        if (nums.Count == 1) return 1;
        var len = nums.Count;
        // size 1 always have nums.Count combination, and square of 1 is 1
        var sum = len;
        for (var size = 2; size < len; size++)
        {
            // use sliding window approach
            var dict = new Dictionary<int, int>();
            var distinct = 0;
            for (var j = 0; j < size; j++)
            {
                if (dict.TryGetValue(nums[j], out var val))
                {
                    dict[nums[j]] = ++val;
                }
                else
                {
                    dict.Add(nums[j], 1);
                    distinct++;
                }
            }
            sum += distinct * distinct;

            for (var i = 1; i < len - size + 1; i++)
            {
                var lastIdx = i - 1;
                var endIdx = i + size - 1;

                if (--dict[nums[lastIdx]] == 0)
                {
                    dict.Remove(nums[lastIdx]);
                    distinct--;
                }

                if (dict.TryGetValue(nums[endIdx], out var val))
                {
                    dict[nums[endIdx]] = ++val;
                }
                else
                {
                    dict.Add(nums[endIdx], 1);
                    distinct++;
                }

                sum += distinct * distinct;
            }
        }
        // size nums.Count have only 1 combination
        var lastCount = new HashSet<int>(nums).Count;
        return sum + (lastCount * lastCount);
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,2,5,5], 22},
        {[1,2,1], 15},
        {[1,1], 3},
        {[2], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SumCounts(input);
        Assert.Equal(expected, actual);
    }
}