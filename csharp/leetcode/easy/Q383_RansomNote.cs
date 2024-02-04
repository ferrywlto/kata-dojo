
namespace dojo.leetcode;

public class Q383_RansomNote
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        return false;
    }
}

public class Q383_RansomNoteTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["a", "b", false],
        ["aa", "ab", false],
        ["aa", "aab", true]
    ];
}

public class Q383_RansomNoteTests
{
    [Theory]
    [ClassData(typeof(Q383_RansomNoteTestData))]
    public static void OfficialTestCases(string ransomNote, string magazine, bool expected)
    {
        var q = new Q383_RansomNote();
        bool result = q.CanConstruct(ransomNote, magazine);
        Assert.Equal(expected, result);
    }
}