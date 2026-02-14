using System.Text;

class Q1021_RemoveOutermostParentheses
{
    // TC: O(n), n is length of s
    // SC: O(n), m is the length of resulting string
    public string RemoveOuterParentheses(string s)
    {
        var started = false;
        var openIdx = 0;
        var openCount = 0;
        var sb = new StringBuilder();
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' && !started)
            {
                started = true;
                openIdx = i;
                openCount++;
            }
            else if (s[i] == '(' && started)
            {
                openCount++;
            }
            else if (s[i] == ')')
            {
                openCount--;
                if (openCount == 0)
                {
                    sb.Append(s.AsSpan(openIdx + 1, i - 1 - openIdx));
                    started = false;
                }
            }
        }
        return sb.ToString();
    }
}
class Q1021_RemoveOutermostParenthesesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["(()())(())", "()()()"],
        ["(()())(())(()(()))", "()()()()(())"],
        ["()()", ""],
    ];
}
public class Q1021_RemoveOutermostParenthesesTests
{
    [Theory]
    [ClassData(typeof(Q1021_RemoveOutermostParenthesesTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1021_RemoveOutermostParentheses();
        var actual = sut.RemoveOuterParentheses(input);
        Assert.Equal(expected, actual);
    }
}
