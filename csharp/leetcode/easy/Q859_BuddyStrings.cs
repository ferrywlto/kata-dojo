
class Q859_BuddyStrings
{
    public bool BuddyStrings(string s, string goal) {
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