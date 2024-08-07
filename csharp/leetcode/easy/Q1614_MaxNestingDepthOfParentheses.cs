class Q1614_MaxNestingDepthOfParaentheses
{
    public int MaxDepth(string s) 
    {
        return 0;    
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