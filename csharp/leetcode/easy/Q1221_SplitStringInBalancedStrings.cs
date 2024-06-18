
class Q1221_SplitStringInBalancedStrings
{
    public int BalancedStringSplit(string s) {
        return 0;
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