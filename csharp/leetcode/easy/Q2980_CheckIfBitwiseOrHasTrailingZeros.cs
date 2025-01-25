public class Q2980_CheckIfBitwiseOrHasTrailingZeros
{
    public bool HasTrailingZeros(int[] nums)
    {
        return false;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[1,2,3,4,5], true},
        {[2,4,8,16], true},
        {[1,3,5,7,9], true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = HasTrailingZeros(input);
        Assert.Equal(expected, actual);
    }
}