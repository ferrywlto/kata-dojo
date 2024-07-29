using System.Text;

class Q1544_MakeTheStringGreat
{
    // TC: O(n), where n is the length of s, using this improved version it only need to iterate in one pass
    // SC: O(n), where n is the length of s, no matter which version used, the same amount of space are needed for the string builder
    public string MakeGood(string s)
    {
            var sb = new StringBuilder(s);
            int i = 0;
            while (i < sb.Length - 1)
            {
                // Both version use this to detect upper-lower pair
                if (Math.Abs(sb[i] - sb[i + 1]) == 32)
                {
                    sb.Remove(i, 2); // Remove the matching pair directly.
                    if (i > 0) i--; // Step back to check for new adjacent matches.
                }
                else i++;
            }
            return sb.ToString();
    }
}
class Q1544_MakeTheStringGreatTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["leEeetcode", "leetcode"],
        ["abBAcC", ""],
        ["s", "s"],
    ];
}
public class Q1544_MakeTheStringGreatTests
{
    [Theory]
    [ClassData(typeof(Q1544_MakeTheStringGreatTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1544_MakeTheStringGreat();
        var actual = sut.MakeGood(input);
        Assert.Equal(expected, actual);
    }
}