public class Q2997_MinNumOpsMakeArrayXorEqualToK//(ITestOutputHelper output)
{
    // 2^20 is closest to 10^6 constraint
    // TC: O(1), time capped at 20 times
    // SC: O(1), space used does not scale with input
    public int MinOperations(int[] nums, int k)
    {
        // Get the final Xor first, then how many bits are different from k then it is the answer  
        var xor = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            xor ^= nums[i];
        }

        var result = 0;
        while (k > 0 || xor > 0)
        {
            if ((k & 1) != (xor & 1)) result++;
            k >>= 1;
            xor >>= 1;
        }
        return result;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[2,1,3,4], 1, 2},
        {[2,0,2,0], 0, 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinOperations(input, k);
        Assert.Equal(expected, actual);
    }
}
