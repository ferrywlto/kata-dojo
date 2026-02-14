public class Q2278_PercentageOfLetterInString
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int PercentageLetter(string s, char letter)
    {
        var count = 0;
        foreach (var c in s)
        {
            if (c == letter) count++;
        }
        var percent = count / (double)s.Length;

        return (int)Math.Floor(percent * 100);
    }
    public static List<object[]> TestData =>
    [
        ["foobar", 'o', 33],
        ["sgawtb", 's', 16],
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
