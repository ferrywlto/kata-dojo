
using System.Text;

namespace dojo.leetcode;

public class Q290_WordPattern
{
    public bool WordPattern(string pattern, string s)
    {
        var patternTokens = pattern.Select(c => c).Distinct().ToArray();
        var strTokens = s.Split(" ");
        var strTokensDistinct = strTokens.Distinct().ToArray();

        if (patternTokens.Length != strTokensDistinct.Length) return false;

        var dict = new Dictionary<string, char>();
        for (var i=0; i<strTokensDistinct.Length; i++)
        {
            dict.Add(strTokensDistinct[i], patternTokens[i]);
        }

        var strBuilder = new StringBuilder();
        for (var j=0; j<strTokens.Length; j++)
        {
            strBuilder.Append(dict[strTokens[j]]);
        }
        return strBuilder.ToString().Equals(pattern);
    }
}

public class Q290_WordPatternTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["abba", "dog cat cat dog", true],
        ["abba", "dog cat cat fish", false],
        ["aaaa", "dog cat cat dog", false],
        ["abc", "b c a", true],
    ];
}

public class Q290_WordPatternTests
{
    [Theory]
    [ClassData(typeof(Q290_WordPatternTestData))]
    public void OfficialTestCases(string input1, string input2, bool expected)
    {
        var sut = new Q290_WordPattern();
        var actual = sut.WordPattern(input1, input2);
        Assert.Equal(expected, actual);
    }
}