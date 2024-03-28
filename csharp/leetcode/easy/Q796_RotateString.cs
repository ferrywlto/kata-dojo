
namespace dojo.leetcode;

public class Q796_RotateString
{
    public bool RotateString(string s, string goal) 
    {
        return false;    
    }
}

public class Q796_RotateStringTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["abcde", "cdeab", true],
        ["abcde", "abced", false],
    ];
}

public class Q796_RotateStringTests
{
    [Theory]
    [ClassData(typeof(Q796_RotateStringTestData))]
    public void OfficialTestCases(string input, string target, bool expected)
    {
        var sut = new Q796_RotateString();
        var actual = sut.RotateString(input, target);
        Assert.Equal(expected, actual);
    }
}