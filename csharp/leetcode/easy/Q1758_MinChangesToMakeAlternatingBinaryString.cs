class Q1758_MinChangesToMakeAlternatingBinaryString
{
    public int MinOperations(string s)
    {
        return 0;
    }
}
class Q1758_MinChangesToMakeAlternatingBinaryStringTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["0100", 1],
        ["10", 0],
        ["1111", 2],
    ];
}
public class Q1758_MinChangesToMakeAlternatingBinaryStringTests
{
    [Theory]
    [ClassData(typeof(Q1758_MinChangesToMakeAlternatingBinaryStringTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1758_MinChangesToMakeAlternatingBinaryString();
        var actual = sut.MinOperations(input);
        Assert.Equal(expected, actual);
    }
}