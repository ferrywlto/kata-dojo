
class Q1417_ReformatString
{
    public string Reformat(string s) 
    {
        return string.Empty;
    }
}
class Q1417_ReformatStringTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["a0b1c2", "0a1b2c"],
        ["leetcode", string.Empty],
        ["1229857369", string.Empty],
    ];
}
public class Q1417_ReformatStringTests
{
    [Theory]
    [ClassData(typeof(Q1417_ReformatStringTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1417_ReformatString();
        var actual = sut.Reformat(input);
        Assert.Equal(expected, actual);
    }
}
