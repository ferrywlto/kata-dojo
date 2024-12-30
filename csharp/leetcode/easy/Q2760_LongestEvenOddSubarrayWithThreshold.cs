public class Q2760_LongestEvenOddSubarrayWithThreshold
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int LongestAlternatingSubarray(int[] nums, int threshold)
    {
        var len = 0;
        var result = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var current = nums[i];
            if (current <= threshold)
            {
                if (current % 2 == len % 2) len++;
                else
                {
                    if (len > result) result = len;
                    len = current % 2 == 0 ? 1 : 0;
                }
            }
            else
            {
                if (len > result) result = len;
                len = 0;
            }
        }
        if (len > result) result = len;
        return result;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[3,2,5,4], 5, 3},
        {[1,2], 2, 1},
        {[2,3,4,5], 4, 3},
        {[4,10,3], 10, 2},
        {[3,5,4], 10, 1},
        {[3], 10, 0},
        {[3], 1, 0},
        {[4], 10, 1},
        {[4], 1, 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int threshold, int expected)
    {
        var actual = LongestAlternatingSubarray(input, threshold);
        Assert.Equal(expected, actual);
    }
}