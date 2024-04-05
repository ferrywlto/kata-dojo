
namespace dojo.leetcode;

public class Q819_MostCommonWord
{
    public string MostCommonWord(string paragraph, string[] banned) 
    {
        return string.Empty;    
    }
}

public class Q819_MostCommonWordTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["Bob hit a ball, the hit BALL flew far after it was hit.", new string[] {"hit"}, "ball"],
        ["a", Array.Empty<string>(), "a"],
    ];
}

public class Q819_MostCommonWordTests
{
    [Theory]
    [ClassData(typeof(Q819_MostCommonWordTestData))]
    public void OfficialTestCases(string input, string[] banned, string expected)
    {
        var sut = new Q819_MostCommonWord();
        var actual = sut.MostCommonWord(input, banned);
        Assert.Equal(expected, actual);
    }
}