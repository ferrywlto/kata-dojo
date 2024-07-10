
class Q1408_StringMatchingInArray
{
    public IList<string> StringMatching(string[] words) 
    {
        return [];    
    }    
}
class Q1408_StringMatchingInArrayTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new string[] {"mass","as","hero","superhero"}, new string[] {"as","hero"}],
        [new string[] {"leetcode","et","code"}, new string[] {"et","code"}],
        [new string[] {"blue","green","bu"}, Array.Empty<string>()],
    ];
}
public class Q1408_StringMatchingInArrayTests
{
    [Theory]
    [ClassData(typeof(Q1408_StringMatchingInArrayTestData))]
    public void OfficialTestCases(string[] input, string[] expected)
    {
        var sut = new Q1408_StringMatchingInArray();
        var actual = sut.StringMatching(input);
        Assert.Equal(expected, actual);
    }
}