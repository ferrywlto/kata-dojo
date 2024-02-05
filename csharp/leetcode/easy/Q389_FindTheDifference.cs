namespace dojo.leetcode;

public class Q389_FindTheDifference
{
    // Constaints
    // t.length == s.length + 1

    // TC: O(n), SC: O(n)
    public char FindTheDifference(string s, string t)
    {
        var dict = s.Analyze();
        foreach(var c in t)
        {
            if (!dict.TryGetValue(c, out var count) || count == 0)
            {
                return c;
            } 
            else 
            {
                dict[c]--;
            }
        }
        throw new ArgumentException("Invalid input: t must have one more character than s");
    }
}

public class Q389_FindTheDifferenceTestData: TestData
{
    protected override List<object[]> Data =>
    [
        ["abcd", "abcde", 'e'],
        ["", "y", 'y'],
        ["a", "aa", 'a'],
        ["ae", "aea", 'a'],
    ];
}

public class Q389_FindTheDifferenceTests
{
    [Theory]
    [ClassData(typeof(Q389_FindTheDifferenceTestData))]
    public void OfficialTestCases(string s, string t, char expected)
    {
        var q = new Q389_FindTheDifference();
        char result = q.FindTheDifference(s, t);
        Assert.Equal(expected, result);
    }
}