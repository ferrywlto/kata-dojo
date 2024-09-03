class Q1784_CheckIfBinaryStringHasAtMostOneSegmentOfOnes
{
    public bool CheckOnesSegment(string s)
    {
        return false;
    }
}
class Q1784_CheckIfBinaryStringHasAtMostOneSegmentOfOnesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["1001", false],
        ["110", true],
    ];
}
public class Q1784_CheckIfBinaryStringHasAtMostOneSegmentOfOnesTests
{
    [Theory]
    [ClassData(typeof(Q1784_CheckIfBinaryStringHasAtMostOneSegmentOfOnesTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q1784_CheckIfBinaryStringHasAtMostOneSegmentOfOnes();
        var actual = sut.CheckOnesSegment(input);
        Assert.Equal(expected, actual);
    }
}