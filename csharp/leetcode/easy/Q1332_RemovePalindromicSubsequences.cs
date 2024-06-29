class Q1332_RemovePalindromicSubsequences
{
    public int RemovePalindromeSub(string s)
    {
        return 0;
    }
}
class Q1332_RemovePalindromicSubsequencesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["ababa", 1],
        ["abb", 2],
        ["baabb", 2],
    ];
}
public class Q1332_RemovePalindromicSubsequencesTests
{
    [Theory]
    [ClassData(typeof(Q1332_RemovePalindromicSubsequencesTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1332_RemovePalindromicSubsequences();
        var actual = sut.RemovePalindromeSub(input);
        Assert.Equal(expected, actual);
    }
}