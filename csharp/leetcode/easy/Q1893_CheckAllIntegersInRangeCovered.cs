class Q1893_CheckAllIntegersInRangeCovered
{
    public bool IsCovered(int[][] ranges, int left, int right)
    {
        return false;
    }
}
class Q1893_CheckAllIntegersInRangeCoveredTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[1,2],[3,4],[5,6]}, 2, 5, true],
        [new int[][] {[1,10],[10,20],}, 21, 21, false],
    ];
}
public class Q1893_CheckAllIntegersInRangeCoveredTests
{
    [Theory]
    [ClassData(typeof(Q1893_CheckAllIntegersInRangeCoveredTestData))]
    public void OfficialTestCases(int[][] input, int left, int right, bool expected)
    {
        var sut = new Q1893_CheckAllIntegersInRangeCovered();
        var actual = sut.IsCovered(input, left, right);
        Assert.Equal(expected, actual);
    }
}