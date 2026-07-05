public class Q3974_MaxTotalSumOfKSelectedElements
{
    public long MaxSum(int[] nums, int k, int mul)
    {
        return 0L;
    }

    public static TheoryData<int[], int, int, int> TestData => new()
    {
        { [6, 1, 2, 9], 3, 2, 26 },
        { [3, 7, 5, 2], 2, 4, 43 },
        { [4, 4], 1, 1, 4 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int mul, int expected)
    {
        var actual = MaxSum(input, k, mul);
        Assert.Equal(expected, actual);
    }
}
