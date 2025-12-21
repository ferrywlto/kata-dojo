public class Q3780_MaxSumOfThreeNumbersDivisibleByThree
{
    public int MaximumSum(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[4,2,3,1], 9},
        {[2,1,5], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumSum(input);
        Assert.Equal(expected, actual);
    }
}
