public class Q383_RansomNote
{
    // TC: O(n), SC: O(n)
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var dict = magazine.ToCharArray().Analyze();
        foreach (var c in ransomNote)
        {
            if (!dict.TryGetValue(c, out int value) || value == 0)
            {
                return false;
            }
            dict[c] = --value;
        }
        return true;
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