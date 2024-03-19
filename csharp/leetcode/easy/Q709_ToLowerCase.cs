
namespace dojo.leetcode;

public class Q709_ToLowerCase
{
    public string ToLowerCase(string s) 
    {
        return string.Empty;       
    }    
}

public class Q709_ToLowerCaseTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["Hello", "hello"],
        ["here", "here"],
        ["LOVELY", "lovely"],
    ];
}

public class Q709_ToLowerCaseTests
{
    [Theory]
    [ClassData(typeof(Q709_ToLowerCaseTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q709_ToLowerCase();
        var actual = sut.ToLowerCase(input);
        Assert.Equal(expected, actual);
    }
}