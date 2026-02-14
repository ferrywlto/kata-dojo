public class Q2932_MaxStrongPairXorI
{
    // Even though the question state that the same number can pick twice to
    // form a strong pair, x ^ x is always 0, so we can ignore same index
    // TC: O(n^2), n scale with length of nums due to trying all pairs
    // SC: O(1), space used does not scale with input
    public int MaximumStrongPairXor(int[] nums)
    {
        var largestXor = 0;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j] && IsStrongPair(nums[i], nums[j]))
                {
                    var xor = nums[i] ^ nums[j];
                    if (xor > largestXor) largestXor = xor;
                }
            }
        }
        return largestXor;
    }
    private bool IsStrongPair(int x, int y) => Math.Abs(x - y) <= Math.Min(x, y);

    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4,5], 7},
        {[10,100], 0},
        {[5,6,25,30], 7},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumStrongPairXor(input);
        Assert.Equal(expected, actual);
    }
}
