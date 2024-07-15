
using System.Runtime.CompilerServices;

class Q1446_ConsecutiveCharacters
{
    public int MaxPower(string s) {
        return 0;   
    }    
}
class Q1446_ConsecutiveCharactersTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["leetcode", 2],
        ["abbcccddddeeeeedcba", 2],
    ];
}
public class Q1446_ConsecutiveCharactersTests
{
    [Theory]
    [ClassData(typeof(Q1446_ConsecutiveCharactersTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1446_ConsecutiveCharacters();
        var actual = sut.MaxPower(input);
        Assert.Equal(expected, actual);
    }
}