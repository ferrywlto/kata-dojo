public class Q3364_MinPositiveSumSubarray
{
    // TC: O(m * n), n scale with length of nums, m scale with r-l
    // SC: O(1), space used does not scale with input 
    public int MinimumSumSubarray(IList<int> nums, int l, int r)
    {
        var min = int.MaxValue;
        for (var size = l; size <= r; size++)
        {
            var sum = 0;
            // initial sum with sliding window
            for (var j = 0; j < size; j++)
            {
                sum += nums[j];
            }

            if (sum > 0 && sum < min) min = sum;
            
            for (var i = 1; i < nums.Count - size + 1; i++)
            {
                sum -= nums[i-1];
                sum += nums[i+size-1];

                if (sum > 0 && sum < min) min = sum;
            }
        }
        return min == int.MaxValue ? -1 : min;
    }
    public static TheoryData<int[], int, int, int> TestData => new()
    {
        {[3, -2, 1, 4], 2, 3, 1},
        {[-2, 2, -3, 1], 2, 3, -1},
        {[1, 2, 3, 4], 2, 4, 3},
        {[7,3 ], 2, 2, 10},
        {[-3, 17], 1, 2, 14},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int l, int r, int expected)
    {
        var actual = MinimumSumSubarray(input, l, r);
        Assert.Equal(expected, actual);
    }
}