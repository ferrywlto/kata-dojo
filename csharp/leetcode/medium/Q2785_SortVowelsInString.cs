public class Q2785_SortVowelsInString
{
    public string SortVowels(string s)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"lEetcOde", "lEOtcede" },
        {"lYmpH", "lYmpH" },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = SortVowels(input);
        Assert.Equal(expected, actual);
    }
}
