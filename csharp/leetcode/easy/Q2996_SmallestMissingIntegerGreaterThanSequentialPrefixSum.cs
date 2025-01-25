public class Q2996_SmallestMissingIntegerGreaterThanSequentialPrefixSum
{
    public int MissingInteger(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,2,5], 6},
        {[3,4,5,1,12,14,13], 15},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MissingInteger(input);
        Assert.Equal(expected, actual);
    }
}