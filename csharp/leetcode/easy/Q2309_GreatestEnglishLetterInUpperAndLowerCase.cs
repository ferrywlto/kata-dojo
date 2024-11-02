public class Q2309_GreatestEnglishLetterInUpperAndLowerCase
{
    public string GreatestLetter(string s)
    {
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