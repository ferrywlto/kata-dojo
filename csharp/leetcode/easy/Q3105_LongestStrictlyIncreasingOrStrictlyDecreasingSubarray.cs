public class Q3105_LongestStrictlyIncreasingOrStrictlyDecreasingSubarray
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int LongestMonotonicSubarray(int[] nums)
    {
        var longest = 1;
        var forward = 1;
        var backward = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                forward++;
                if (forward > longest) longest = forward;
            }
            else forward = 1;

            if (nums[^(i + 1)] > nums[^i])
            {
                backward++;
                if (backward > longest) longest = backward;
            }
            else backward = 1;
        }
        return longest;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[1,4,3,3,2], 2},
        {[3,3,3,3], 1},
        {[3,2,1], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = LongestMonotonicSubarray(input);
        Assert.Equal(expected, actual);
    }
}
