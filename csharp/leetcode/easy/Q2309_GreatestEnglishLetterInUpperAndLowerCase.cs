public class Q2309_GreatestEnglishLetterInUpperAndLowerCase(ITestOutputHelper output)
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public string GreatestLetter(string s)
    {
        var upper = new int[26];
        var lower = new int[26];
        foreach (var c in s)
        {
            if (c >= 'A' && c <= 'Z')
            {
                upper[c - 'A']++;
                output.WriteLine("{0}: {1}", c, upper[c - 'A']);
            }
            else if (c >= 'a' && c <= 'z')
            {
                lower[c - 'a']++;
                output.WriteLine("{0}: {1}", c, upper[c - 'a']);
            }
        }
        for (var i = 25; i >= 0; i--)
        {
            output.WriteLine("{0}: {1}, {2}", ((char)(i + 'A')), upper[i], lower[i]);
            if (upper[i] > 0 && lower[i] > 0)
            {
                return ((char)(i + 'A')).ToString();
            }
        }
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        ["lEeTcOdE", "E"],
        ["arRAzFif", "R"],
        ["AbCdEfGhIjK", ""],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = GreatestLetter(input);
        Assert.Equal(expected, actual);
    }
}