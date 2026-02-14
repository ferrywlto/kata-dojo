class Q1221_SplitStringInBalancedStrings
{
    // TC: O(n), n is length of s
    // SC: O(1), the dictionary size is fixed
    public int BalancedStringSplit(string s)
    {
        var result = 0;
        var countL = 0;
        var countR = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == 'L') countL++;
            else countR++;

            if (countL == countR)
            {
                result++;
                countL = 0;
                countR = 0;
            }
        }
        return result;
    }
}
class Q1221_SplitStringInBalancedStringsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["RLRRLLRLRL", 4],
        ["RLRRRLLRLL", 2],
        ["LLLLRRRR", 1],
    ];
}
public class Q1221_SplitStringInBalancedStringsTests
{
    [Theory]
    [ClassData(typeof(Q1221_SplitStringInBalancedStringsTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1221_SplitStringInBalancedStrings();
        var actual = sut.BalancedStringSplit(input);
        Assert.Equal(expected, actual);
    }
}
