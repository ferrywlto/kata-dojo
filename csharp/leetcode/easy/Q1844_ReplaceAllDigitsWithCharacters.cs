using System.Text;

class Q1844_ReplaceAllDigitsWithCharacters
{
    // TC: O(n), where n is length of s/2
    // SC: O(n), where n is length of s due to string builder to hold the string
    public string ReplaceDigits(string s)
    {
        var sb = new StringBuilder(s);
        for (var i = 1; i < s.Length; i += 2)
        {
            sb[i] = (char)(s[i - 1] + (s[i] - 48));
        }
        return sb.ToString();
    }
}
class Q1844_ReplaceAllDigitsWithCharactersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["a1c1e1", "abcdef"],
        ["a1c1e", "abcde"],
        ["a1b2c3d4e", "abbdcfdhe"],
    ];
}
public class Q1844_ReplaceAllDigitsWithCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1844_ReplaceAllDigitsWithCharactersTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1844_ReplaceAllDigitsWithCharacters();
        var actual = sut.ReplaceDigits(input);
        Assert.Equal(expected, actual);
    }
}