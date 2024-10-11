public class Q2124_CheckIfAllAAppearsBeforeAllB
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input 
    public bool CheckString(string s)
    {
        var lastAIdx = -1;
        var firstBIdx = int.MaxValue;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == 'a')
            {
                if (firstBIdx == int.MaxValue) lastAIdx = i;
                else return false;
            }
            else if (firstBIdx == int.MaxValue) firstBIdx = i;
        }
        return lastAIdx < firstBIdx;
    }
    public static List<object[]> TestData =>
    [
        ["aaabbb", true],
        ["abab", false],
        ["bbb", true],
        ["aaa", true],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = CheckString(input);
        Assert.Equal(expected, actual);
    }
}