class Q1893_CheckAllIntegersInRangeCovered
{
    // TC: O(n * m), where n is length of ranges and m is (right - left + 1)
    // SC: O(1), space used does not scale with input
    public bool IsCovered(int[][] ranges, int left, int right)
    {
        for (var i = left; i <= right; i++)
        {
            var covered = false;
            foreach (var range in ranges)
            {
                if (i >= range[0] && i <= range[1])
                {
                    covered = true;
                    break;
                }
            }
            if (!covered) return false;
        }
        return true;
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