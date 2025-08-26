public class Q2317_MaxXorAfterOperations
{
    public int MaximumXOR(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[3,2,4,6], 7},
        {[1,2,3,9,2], 11},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumXOR(input);
        Assert.Equal(expected, actual);
    }
}
