
class Q859_BuddyStrings
{
    // TC: O(n), n is length of s
    // SC: O(n), n is unique characters in s
    public bool BuddyStrings(string s, string goal)
    {
        if (s.Length != goal.Length) return false;
        if (s.Length < 2) return false;
        var diffCount = 0;
        char[,] diff = new char[2, 2];
        var set = new HashSet<char>();
        var anyMoreThanOnce = false;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != goal[i])
            {
                if (diffCount >= 2) return false;
                diff[diffCount, 0] = s[i];
                diff[diffCount, 1] = goal[i];
                diffCount++;
            }
            if (!set.Add(s[i])) anyMoreThanOnce = true;
        }
        if (diffCount == 2)
        {
            if (diff[0, 0] == diff[1, 1] && diff[0, 1] == diff[1, 0]) return true;
        }
        if (diffCount == 0 && s.Length == 2 && s[0] != s[1]) return false;
        if (diffCount == 0)
        {
            return anyMoreThanOnce;
        }
        return false;
    }
}

class Q859_BuddyStringsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["ab", "ba", true],
        ["ab", "ab", false],
        ["aa", "aa", true],
        ["abcaa", "abcbb", false],
        ["abcd", "abcd", false],
        ["abab", "abab", true],
        ["aaab", "aaab", true],
    ];
}

public class Q859_BuddyStringsTests
{
    [Theory]
    [ClassData(typeof(Q859_BuddyStringsTestData))]
    public void OfficialTestCases(string s, string goal, bool expected)
    {
        var sut = new Q859_BuddyStrings();
        var actual = sut.BuddyStrings(s, goal);
        Assert.Equal(expected, actual);
    }
}
