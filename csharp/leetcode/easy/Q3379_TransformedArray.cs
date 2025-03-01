public class Q3379_TransformedArray
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int[] ConstructTransformedArray(int[] nums)
    {
        var len = nums.Length;
        var result = new int[len];
        for (var i = 0; i < len; i++)
        {
            var idx = nums[i] > 0
            ? (i + nums[i]) % len
            : nums[i] < 0
                // Negative modulus forumla
                ? ((i + nums[i]) % len + len) % len
                : i;

            result[i] = nums[idx];
        }
        return result;
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[3,-2,1,1], [1,1,1,3]},
        {[-1,4,-1], [-1,-1,4]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = ConstructTransformedArray(input);
        Assert.Equal(expected, actual);
    }
}