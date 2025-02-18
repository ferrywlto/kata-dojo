public class Q3280_ConvertDateToBinary
{
    public string ConvertDateToBinary(string date)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"2080-02-29", "100000100000-10-11101"},
        {"1900-01-01", "11101101100-1-1"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = ConvertDateToBinary(input);
        Assert.Equal(expected, actual);
    }
}