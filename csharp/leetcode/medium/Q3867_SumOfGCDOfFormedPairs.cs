public class Q3867_SumOfGCDOfFormedPairs
{
    public long GcdSum(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new() { { [2, 6, 4], 2 }, { [3, 6, 2, 8], 5 }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = GcdSum(input);
        Assert.Equal(expected, actual);
    }
}
