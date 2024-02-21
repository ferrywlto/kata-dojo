
namespace dojo.leetcode;

public class Q541_ReverseStringII
{
    public string ReverseStr(string s, int k) {
        return string.Empty;    
    }
}

public class Q541_ReverseStringIITestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["abcdefg", 2, "bacdfeg"],
        ["abcd", 2, "bacd"],
        ["abcdefgh", 3, "cbadefgh"],
    ];
}

public class Q541_ReverseStringIITests
{
    [Theory]
    [ClassData(typeof(Q541_ReverseStringIITestData))]
    public void OfficialTestCases(string input, int k, string expected)
    {
        var sut = new Q541_ReverseStringII();
        var actual = sut.ReverseStr(input, k);
        Assert.Equal(expected, actual);
    }
}