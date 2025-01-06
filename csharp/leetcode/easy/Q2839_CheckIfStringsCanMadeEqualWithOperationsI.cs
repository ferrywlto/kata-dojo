using System.Text;

public class Q2839_CheckIfStringsCanMadeEqualWithOperationsI//(ITestOutputHelper output)
{
    // TC: O(1), only 4 combinations
    // SC: O(n), n scale with length of s1
    public bool CanBeEqual(string s1, string s2)
    {
        if (s1 == s2) return true;

        var sb = new StringBuilder(s1);
        // there could be 4 possible combinations
        // 1. unchange
        // 2. swap idx 0 and 2
        // 3. swap idx 1 and 3
        // 4. swap both 0,2 and 1,3
        (sb[2], sb[0]) = (sb[0], sb[2]);
        if (sb.ToString() == s2) return true;

        sb.Clear();
        sb.Append(s1);
        (sb[3], sb[1]) = (sb[1], sb[3]);
        if (sb.ToString() == s2) return true;

        sb.Clear();
        sb.Append(s1);
        (sb[2], sb[0]) = (sb[0], sb[2]);
        (sb[3], sb[1]) = (sb[1], sb[3]);
        return sb.ToString() == s2;
    }
    public static TheoryData<string, string, bool> TestData => new()
    {
        {"abcd", "cdab", true},
        {"abcd", "dacb", false},
        {"bnxw", "bwxn", true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, bool expected)
    {
        var actual = CanBeEqual(input1, input2);
        Assert.Equal(expected, actual);
    }
}