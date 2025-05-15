public class Q1829_MaxXorForEachQuery
{
    // TC: O(n), n scale with length of nums
    // SC: O(n), to hold the result, otherwise O(1)
    public int[] GetMaximumXor(int[] nums, int maximumBit)
    {
        var result = new int[nums.Length];
        var bitMask = (1 << maximumBit) - 1;

        var xor = nums[0];
        result[0] = xor ^ bitMask;

        for (var i = 1; i < nums.Length; i++)
        {
            xor ^= nums[i];
            result[i] = xor ^ bitMask;
        }

        Array.Reverse(result);
        return result;
    }
    public static TheoryData<int[], int, int[]> TestData => new()
    {
        {[0,1,1,3], 2, [0,3,2,3]},
        {[2,3,4,7], 3, [5,2,6,5]},
        {[0,1,2,2,5,7], 3, [4,3,6,4,6,7]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int[] expected)
    {
        var actual = GetMaximumXor(input, k);
        Assert.Equal(expected, actual);
    }
}