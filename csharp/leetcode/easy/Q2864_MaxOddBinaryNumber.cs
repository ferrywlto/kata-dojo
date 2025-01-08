public class Q2864_MaxOddBinaryNumber
{
    public string MaximumOddBinaryNumber(string s)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"010", "001"},
        {"0101", "1001"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = MaximumOddBinaryNumber(input);
        Assert.Equal(expected, actual);
    }
}