public class Q2062_CountVowelSubstringsOfString
{
    public int CountVowelSubstrings(string word)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        ["aeiouu", 2],
        ["unicornarihan", 0],
        ["cuaieuouac", 7],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountVowelSubstrings(input);
        Assert.Equal(expected, actual);
    }
}