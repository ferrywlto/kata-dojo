public class Q2765_LongestAlternatingSubarray
{
    // TC: O(n), n scale with length of nums, just need single pass
    // SC: O(1), space used does not scale with input
    public int AlternatingSubarray(int[] nums)
    {
        var result = -1;
        var len = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            var diff = nums[i] - nums[i - 1];
            var alt = (len == 0 || len % 2 != 0) ? 1 : -1;

            if (diff == alt)
            {
                if (len == 0) len = 2;
                else len++;
            }
            else
            {
                if (len > result) result = len;
                len = (diff == 1) ? 2 : 0;
            }
        }
        if (len > result) result = len;
        if (result == 0) return -1;
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,6,4,10,8], -1},
        {[2,3,4,3,4], 4},
        {[2,3,4,3], 3},
        {[2,3,4,3,4,4], 4},
        {[2,3,4,3,3], 3},
        {[4,5,6], 2},
        {[1,2], 2},
        {[1,1], -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = AlternatingSubarray(input);
        Assert.Equal(expected, actual);
    }
}