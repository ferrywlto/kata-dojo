public class Q3856_TrimTrailingVowels
{
    public string TrimTrailingVowels(string s)
    {
        return "";
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"idea", "id"},
        {"day", "day"},
        {"aeiou", "aeiou"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = TrimTrailingVowels(input);
        Assert.Equal(expected, actual);
    }
}
