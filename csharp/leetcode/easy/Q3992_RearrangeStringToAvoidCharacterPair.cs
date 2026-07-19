using System.Text;

public class Q3992_RearrangeStringToAvoidCharacterPair
{
    public string RearrangeString(string s, char x, char y)
    {
        var sb_t = new StringBuilder();
        var sb_x = new StringBuilder();
        var sb_s = new StringBuilder();

        foreach (var ch in s)
        {
            if (ch == x) sb_x.Append(ch);
            else if (ch == y) sb_t.Append(ch);
            else sb_s.Append(ch);
        }

        return sb_t.Append(sb_s).Append(sb_x).ToString();
    }

    public static TheoryData<string, char, char, string> TestData => new()
    {
        { "aabc", 'a', 'c', "cbaa" },
        { "dcab", 'd', 'b', "bcad" },
        { "axe", 'o', 'x', "xae" }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, char x, char y, string expected)
    {
        var actual = RearrangeString(input, x, y);
        Assert.Equal(expected, actual);
    }
}
