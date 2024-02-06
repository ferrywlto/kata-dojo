namespace dojo.leetcode;

public class Q392_IsSubsequence
{
    public bool IsSubsequence(string s, string t)
    {
        return false;
    }
}

public class Q392_IsSubsequenceTestData: TestData
{
    protected override List<object[]> Data =>
    [
        ["abc", "ahbgdc", true],
        ["axc", "ahbgdc", false],
    ];
}

public class Q392_IsSubsequenceTests
{
    [Theory]
    [ClassData(typeof(Q392_IsSubsequenceTestData))]
    public void OfficialTestCases(string s, string t, bool expected)
    {
        var q = new Q392_IsSubsequence();
        bool result = q.IsSubsequence(s, t);
        Assert.Equal(expected, result);
    }
}
