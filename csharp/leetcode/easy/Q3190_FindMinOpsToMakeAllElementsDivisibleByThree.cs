public class Q3190_FindMinOpsToMakeAllElementsDivisibleByThree
{
    public int MinimumOperations(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4], 3},
        {[3,6,9], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumOperations(input);
        Assert.Equal(expected, actual);
    }
}