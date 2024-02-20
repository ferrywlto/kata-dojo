
namespace dojo.leetcode;

public class Q521_LongestUncommonSubsequence
{
    // TC: O(n), because of == operator
    // SC: O(1)
    public int FindLUSlength(string a, string b) 
    {
        if (a == b) return -1;
        if (a.Length > b.Length) return a.Length;
        return b.Length;
    }
}

public class Q521_LongestUncommonSubsequenceTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["aba", "cdc", 3],
        ["aba", "aba", -1],
        ["aba", "ab", 3],
        ["aba", "a", 3],
        ["aba", "ba", 3]
    ];
}

public class Q521_LongestUncommonSubsequenceTests
{
    [Theory]
    [ClassData(typeof(Q521_LongestUncommonSubsequenceTestData))]
    public void OfficialTestCases(string a, string b, int expected)
    {
        var sut = new Q521_LongestUncommonSubsequence();
        var actual = sut.FindLUSlength(a, b);
        Assert.Equal(expected, actual);
    }
}