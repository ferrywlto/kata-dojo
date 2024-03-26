
namespace dojo.leetcode;

public class Q748_ShortestCompletingWord
{
     public string ShortestCompletingWord(string licensePlate, string[] words) 
     {
        return string.Empty;   
    }   
}

public class Q748_ShortestCompletingWordTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["1s3 PSt", new string[]{"step","steps","stripe","stepple"}, "steps"],
        ["1s3 456", new string[]{"looks","pest","stew","show"}, "pest"],
    ];
}

public class Q748_ShortestCompletingWordTests
{
    [Theory]
    [ClassData(typeof(Q748_ShortestCompletingWordTestData))]
    public void OfficialTestCases(string input, string[] words, string expected)
    {
        var sut = new Q748_ShortestCompletingWord();
        var actual = sut.ShortestCompletingWord(input, words);
        Assert.Equal(expected, actual);
    }
}