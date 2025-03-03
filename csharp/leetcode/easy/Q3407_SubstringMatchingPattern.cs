public class Q3407_SubstringMatchingPattern
{
    // TC: O(n), n scale with length of s due to s.IndexOf() and s.LastIndexOf()
    // SC: O(1), space used does not scale with input
    public bool HasMatch(string s, string p)
    {
        if (p.Length == 1) return true;

        var pArr = p.Split('*');
        var strBeforeAnchor = pArr[0];
        var strAfterAnchor = pArr[1];

        var sHead = s.IndexOf(strBeforeAnchor);
        if (sHead == -1) return false;
        var sTail = s.LastIndexOf(strAfterAnchor);
        if (sTail == -1) return false;

        return sTail >= sHead + strBeforeAnchor.Length;
    }
    public static TheoryData<string, string, bool> TestData => new()
    {
        {"leetcode", "ee*e", true},
        {"car", "c*v", false},
        {"luck", "u*", true},
        {"kvb", "k*v", true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, bool expected)
    {
        var actual = HasMatch(input1, input2);
        Assert.Equal(expected, actual);
    }
}