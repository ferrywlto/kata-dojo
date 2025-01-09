public class Q2869_MinOperationsToCollectElements
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public int MinOperations(IList<int> nums, int k)
    {
        var sum = (1 + k) * k / 2;
        var set = new HashSet<int>();
        for (var i = 0; i < nums.Count; i++)
        {
            var last = nums[^(i + 1)];
            if (last <= k && set.Add(last))
            {
                sum -= last;
                if (sum == 0)
                {
                    return i + 1;
                }
            }
        }
        return -1;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[3,1,5,4,2], 2, 4},
        {[3,1,5,4,2], 5, 5},
        {[3,2,5,3,1], 3, 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinOperations(input, k);
        Assert.Equal(expected, actual);
    }
}