public class Q2259_RemoveDigitFromNumberToMaxResult
{
    public string RemoveDigit(string number, char digit)
    {
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        ["123", '3', "12"],
        ["1231", '1', "231"],
        ["551", '5', "51"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, char digit, string expected)
    {
        var actual = RemoveDigit(input, digit);
        Assert.Equal(expected, actual);
    }
}