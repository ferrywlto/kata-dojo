public class Q2980_CheckIfBitwiseOrHasTrailingZeros
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public bool HasTrailingZeros(int[] nums)
    {
        var count = 0;
        foreach (var n in nums)
        {
            if (n % 2 == 0)
            {
                count++;
                if (count == 2) return true;
            }
        }
        return false;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[1,2,3,4,5], true},
        {[2,4,8,16], true},
        {[1,3,5,7,9], false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = HasTrailingZeros(input);
        Assert.Equal(expected, actual);
    }
}