
namespace dojo.leetcode;

public class Q459_RepeatedSubstring
{
    public bool RepeatedSubstringPattern(string s)
    {
        return false;
    }
}

public class Q459_RepeatedSubstringTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["abab", true],
        ["aba", false],
        ["abcabcabcabc", true],
        ["abcabcabc", true],
        ["abcabcab", false],
        ["abcabc", true],
        ["abcab", false],
        ["abc", false],
        ["ab", false],
        ["a", false],
        ["", false],
    ];
}

public class Q459_RepeatedSubstringTests
{
    [Theory]
    [ClassData(typeof(Q459_RepeatedSubstringTestData))]
    public void Test_RepeatedSubstringPattern(string s, bool expected)
    {
        var sut = new Q459_RepeatedSubstring();
        var actual = sut.RepeatedSubstringPattern(s);
        Assert.Equal(expected, actual);
    }
}