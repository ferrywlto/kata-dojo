class Q1614_MaxNestingDepthOfParaentheses
{
    // TC: O(n), where n is length of s, it has to run through the whole string to find the max depth
    // SC: O(1), space used is fixed
    public int MaxDepth(string s)
    {
        var depth = 0;
        var maxDepth = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                depth++;
                if (depth > maxDepth) maxDepth = depth;
            }
            else if (s[i] == ')') depth--;
        }
        return maxDepth;
    }
}
class Q1614_MaxNestingDepthOfParaenthesesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["(1+(2*3)+((8)/4))+1", 3],
        ["(1)+((2))+(((3)))", 3],
        ["()(())((()()))", 3],
    ];
}
public class Q1614_MaxNestingDepthOfParaenthesesTests
{
    [Theory]
    [ClassData(typeof(Q1614_MaxNestingDepthOfParaenthesesTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1614_MaxNestingDepthOfParaentheses();
        var actual = sut.MaxDepth(input);
        Assert.Equal(expected, actual);
    }
}
