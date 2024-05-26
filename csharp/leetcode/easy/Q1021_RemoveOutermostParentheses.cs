
class Q1021_RemoveOutermostParentheses
{
    public string RemoveOuterParentheses(string s) {
        return string.Empty;    
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