public class Q2932_MaxStrongPairXorI
{
    public int MaximumStrongPairXor(int[] nums)
    {
        return 0;
    }
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