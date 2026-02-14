using System.Text;

public class Q1957_DeleteCharactersToMakeFancyString
{
    // TC: O(n), n scale with length of s
    // SC: O(n), n scale with length of s, worst case it equals length of s if all characters doesn't reoccur three times consetutively.
    public string MakeFancyString(string s)
    {
        if (s.Length <= 2) return s;

        var lastChar = s[0];
        var reoccurance = 1;
        var sb = new StringBuilder();
        sb.Append(s[0]);

        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] == lastChar && reoccurance == 2) continue;

            if (s[i] == lastChar) reoccurance++;
            else
            {
                reoccurance = 1;
                lastChar = s[i];
            }
            sb.Append(s[i]);
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
