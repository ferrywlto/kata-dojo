public class Q2278_PercentageOfLetterInString
{
    public int PercentageLetter(string s, char letter)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        ["foobar", 'o', 33],
        ["jjjj", 'k', 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, char c, int expected)
    {
        var actual = PercentageLetter(input, c);
        Assert.Equal(expected, actual);
    }
}