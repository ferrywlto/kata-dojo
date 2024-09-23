using System.Text;

public class Q1957_DeleteCharactersToMakeFancyString
{
    public string MakeFancyString(string s)
    {
        if (s.Length <= 2) return s;

        var lastChar = s[0];
        var reoccurance = 1;
        var sb = new StringBuilder();
        sb.Append(s[0]);

        if (s[1] == lastChar) reoccurance++;
        else
        {
            reoccurance = 1;
            lastChar = s[1];
        }
        sb.Append(s[1]);

        for (var i = 2; i < s.Length; i++)
        {
            if (s[i] == lastChar)
            {
                if (reoccurance == 2) continue;
                else
                {
                    reoccurance++;
                    sb.Append(s[i]);
                }
            }
            else
            {
                lastChar = s[i];
                reoccurance = 1;
                sb.Append(s[i]);
            }
        }

        return sb.ToString();
    }

    public static IEnumerable<object[]> TestData =>
    [
        ["leeetcode", "leetcode"],
        ["aaabaaaa", "aabaa"],
        ["aab", "aab"],
    ];

    [Theory]
    [MemberData(nameof(TestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var actual = MakeFancyString(input);
        Assert.Equal(expected, actual);
    }
}