public class Q2899_LastVisitedIntegers
{
    // TC: O(n), n scale with length of nums
    // SC: O(n+m), n scale with number of positive integers in nums, m scale with length of result
    public IList<int> LastVisitedIntegers(int[] nums)
    {
        var ans = new List<int>();
        var seen = new List<int>();
        var neg = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                neg = 0;
                seen.Add(nums[i]);
            }
            else
            {
                neg++;
                if (neg > seen.Count) ans.Add(-1);
                else ans.Add(seen[^neg]);
            }
        }
        return ans;
    }
    public static TheoryData<int[], List<int>> TestData => new()
    {
        {[1,2,-1,-1,-1], [2,1,-1]},
        {[1,-1,2,-1,-1], [1,2,1]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, List<int> expected)
    {
        var actual = LastVisitedIntegers(input);
        Assert.Equal(expected, actual);
    }
}
