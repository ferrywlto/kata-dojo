public class Q3982_SumOfIntegersWithMaxDigitRange
{
    public int MaxDigitRange(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[5724,111,350], 6074},
        {[90,900], 990},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxDigitRange(input);
        Assert.Equal(expected, actual);
    }
}
