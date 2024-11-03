public class Q1763_LongestNiceSubstring
{
    public string LongestNiceSubstring(string s)
    {
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        ["YazaAay", "aAa"],
        ["Bb", "Bb"],
        ["c", ""],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = LongestNiceSubstring(input);
        Assert.Equal(expected, actual);
    }
}