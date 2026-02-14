public class Q3280_ConvertDateToBinary
{
    // TC: O(1)
    // SC: O(1)
    public string ConvertDateToBinary(string date)
    {
        var year = int.Parse(date.Substring(0, 4));
        var month = int.Parse(date.Substring(5, 2));
        var day = int.Parse(date.Substring(8, 2));

        return $"{year:b}-{month:b}-{day:b}";
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
