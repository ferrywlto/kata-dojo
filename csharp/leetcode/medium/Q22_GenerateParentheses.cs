public class Q22_GenerateParentheses
{
    public IList<string> GenerateParenthesis(int n) {
        return [];
    }    
    public static TheoryData<int, List<string>> TestData => new ()
    {
        {3, ["((()))","(()())","(())()","()(())","()()()"]},
        {1, ["()"]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, List<string> expected)
    {
        var actual = GenerateParenthesis(input);
        Assert.Equal(expected, actual);
    }
}
