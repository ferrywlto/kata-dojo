public class Q2124_CheckIfAllAAppearsBeforeAllB
{
    public bool CheckString(string s)
    {
        return false;
    }
    public static List<object[]> TestData =>
    [
        ["aaabbb", true],
        ["abab", false],
        ["bbb", true],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = CheckString(input);
        Assert.Equal(expected, actual);
    }
}