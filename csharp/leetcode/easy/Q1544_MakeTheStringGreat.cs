class Q1544_MakeTheStringGreat
{
    public string MakeGood(string s)
    {
        return string.Empty;
    }
}
class Q1544_MakeTheStringGreatTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["leEeetcode", "leetcode"],
        ["abBAcC", ""],
        ["s", "s"],
    ];
}
public class Q1544_MakeTheStringGreatTests
{
    [Theory]
    [ClassData(typeof(Q1544_MakeTheStringGreatTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1544_MakeTheStringGreat();
        var actual = sut.MakeGood(input);
        Assert.Equal(expected, actual);
    }
}