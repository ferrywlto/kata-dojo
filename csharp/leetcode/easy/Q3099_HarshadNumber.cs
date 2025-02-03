public class Q3099_HarshadNumber
{
    public int SumOfTheDigitsOfHarshadNumber(int x)
    {
        return 0;
    }
    
    public static TheoryData<int, int> TestData => new()
    {
        {18, 9},
        {23, -1},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = SumOfTheDigitsOfHarshadNumber(input);
        Assert.Equal(expected, actual);
    }
}