public class Q2913_SubarraysDistinctElementSumOfSquaresI
{
    // TC: O(n^3), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums, worst case nums
    public int SumCounts(IList<int> nums)
    {
        var sum = 0;
        for (var size = 2; size <= nums.Count; size++)
        {
            for (var i = 0; i < nums.Count - size + 1; i++)
            {
                var set = new HashSet<int>();
                for (var j = i; j < i + size; j++)
                {
                    set.Add(nums[j]);
                }
                sum += set.Count * set.Count;
            }
        }
        return sum + nums.Count;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,1], 15},
        {[1,1], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SumCounts(input);
        Assert.Equal(expected, actual);
    }
}