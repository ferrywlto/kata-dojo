class Q1566_DetectPatternOfLengthMRepeatedKOrMoreTimes
{
    public bool ContainsPattern(int[] arr, int m, int k)
    {
        return false;
    }
}
class Q1566_DetectPatternOfLengthMRepeatedKOrMoreTimesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,4,4,4,4}, 1, 3, true],
        [new int[] {1,2,1,2,1,1,1,3}, 2, 2, true],
        [new int[] {1,2,1,2,1,3}, 2, 3, false],
    ];
}
public class Q1566_DetectPatternOfLengthMRepeatedKOrMoreTimesTests
{
    [Theory]
    [ClassData(typeof(Q1566_DetectPatternOfLengthMRepeatedKOrMoreTimesTestData))]
    public void OfficialTestCases(int[] input, int m, int k, bool expected)
    {
        var sut = new Q1566_DetectPatternOfLengthMRepeatedKOrMoreTimes();
        var actual = sut.ContainsPattern(input, m, k);
        Assert.Equal(expected, actual);
    }
}