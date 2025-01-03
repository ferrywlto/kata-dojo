public class Q2810_FaultyKeyboard
{
    public string FinalString(string s)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"string", "rtsng"},
        {"poiinter", "ponter"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = FinalString(input);
        Assert.Equal(expected, actual);
    }
}
