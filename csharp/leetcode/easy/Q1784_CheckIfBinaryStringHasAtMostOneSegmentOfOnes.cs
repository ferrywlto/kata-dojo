class Q1784_CheckIfBinaryStringHasAtMostOneSegmentOfOnes
{
    // TC: O(n), where n is length of s
    // SC: O(1), space used is fixed
    public bool CheckOnesSegment(string s)
    {
        var count = 0;
        for (var i = 0; i < s.Length - 1; i++)
        {
            if (s[i] != s[i + 1]) count++;
            // Early termination
            if (count > 1) return false;
        }
        return count <= 1;
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