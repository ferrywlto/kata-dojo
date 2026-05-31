public class Q3945_DigitFrequencyScore
{
    public int DigitFrequencyScore(int n)
    {
        return 0;
    }

    public static TheoryData<int, int> TestData => new()
    {
        { 122, 5 },
        { 101, 2 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = DigitFrequencyScore(input);
        Assert.Equal(expected, actual);
    }
}
