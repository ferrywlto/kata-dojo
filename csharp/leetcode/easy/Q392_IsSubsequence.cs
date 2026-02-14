class Q392_IsSubsequence
{
    // TC: O(n), SC: O(1)
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0) return true;
        else if (t.Length == 0) return false;

        var longIdx = 0;
        var shortIdx = 0;

        while (longIdx < t.Length && shortIdx < s.Length)
        {
            if (t[longIdx] == s[shortIdx])
            {
                shortIdx++;
            }
            longIdx++;
        }
        return shortIdx >= s.Length;
    }
}

class Q392_IsSubsequenceTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["abc", "ahbgdc", true],
        ["abc", "hagbdc", true],
        ["axc", "ahbgdc", false],
        ["b", "abc", true],
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
