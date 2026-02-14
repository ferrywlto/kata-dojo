class Q1893_CheckAllIntegersInRangeCovered
{
    // TC: O(n * m), where n is length of ranges and m is (right - left + 1)
    // SC: O(1), space used does not scale with input
    public bool IsCovered(int[][] ranges, int left, int right)
    {
        // Difference array, size 52 to handle up to 50 + 1
        int[] diff = new int[52];

        // Mark the ranges in the difference array
        // it looks like this:
        // [0,1,0,0,0,0,0,0,0,0,1,-1,0,0,0,0,0,0,0,0,0,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]
        foreach (var range in ranges)
        {
            diff[range[0]]++;
            diff[range[1] + 1]--;
        }

        // Calculate the prefix sum up to left - 1
        int curr = 0;
        for (int i = 1; i < left; i++)
            curr += diff[i];

        // Calculate the prefix sum within the interval [left, right] and check coverage
        for (int i = left; i <= right; i++)
        {
            curr += diff[i];
            if (curr <= 0) return false;
        }
        return true;
    }
}
class Q1893_CheckAllIntegersInRangeCoveredTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[1,2],[3,4],[5,6]}, 2, 5, true],
        [new int[][] {[1,10],[10,20]}, 21, 21, false],
        [new int[][] {[1,50]}, 1, 50, true],
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
