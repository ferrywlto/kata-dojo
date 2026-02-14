public class Q2859_SumValuesAtIndicesWithKSetBits
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int SumIndicesWithKSetBits(IList<int> nums, int k)
    {
        var result = 0;
        for (var i = 0; i < nums.Count; i++)
        {
            if (SetBits(i) == k) result += nums[i];
        }
        return result;
    }
    private static int SetBits(int input)
    {
        var result = 0;
        while (input > 0)
        {
            if ((input & 1) == 1) result++;
            input >>= 1;
        }
        return result;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[5,10,1,5,2], 1, 13},
        {[4,3,2,1], 2, 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = SumIndicesWithKSetBits(input, k);
        Assert.Equal(expected, actual);
    }
}
