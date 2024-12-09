public class Q2609_FindLongestBalancedSubstring
{
    public int FindTheLongestBalancedSubstring(string s)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        ["01000111", 6],
        ["00111", 4],
        ["111", 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = FindTheLongestBalancedSubstring(input);
        Assert.Equal(expected, actual);
    }
}