class Q1370_IncreasingDecreasingString
{
    public string SortString(string s) 
    {
        return string.Empty;    
    }    
}
class Q1370_IncreasingDecreasingStringTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["aaaabbbbcccc", "abccbaabccba"],
        ["rat", "art"],
    ];
}
public class Q1370_IncreasingDecreasingStringTests
{
    [Theory]
    [ClassData(typeof(Q1370_IncreasingDecreasingStringTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1370_IncreasingDecreasingString();
        var actual = sut.SortString(input);
        Assert.Equal(expected, actual);
    }
}