using System.Text;

class Q1576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharacters
{
    // TC: O(n), where n is the length of s * 24 at most
    // SC: O(n), where n is the length of s to hold the result
    public string ModifyString(string s)
    {
        if (s.Length == 1) return s[0] == '?' ? "a" : s;

        var sb = new StringBuilder(s);
        for (var i = 0; i < sb.Length; i++)
        {
            if (sb[i] == '?')
            {
                char prev = i > 0 ? sb[i - 1] : '\0';
                char next = i < sb.Length - 1 ? sb[i + 1] : '\0';
                sb[i] = GetNextAvailable(prev, next);
            }
        }
        return sb.ToString();
    }
    public char GetNextAvailable(char a, char b)
    {
        for (char i = 'a'; i <= 'z'; i++)
        {
            if (i != a && i != b) return i;
        }
        return 'a';
    }
}
class Q1576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharactersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["?zs", "azs"],
        ["ubv?w", "ubvaw"],
    ];
}
public class Q1576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharactersTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1576_ReplaceAllQuestionMarksToAvoidConsecutiveRepeatingCharacters();
        var actual = sut.ModifyString(input);
        Assert.Equal(expected, actual);
    }
}
