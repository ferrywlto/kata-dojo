
namespace dojo.leetcode;

public class Q495_TeemoAttacking
{
    // TC:O(n), SC: O(1)
    public int FindPoisonedDuration(int[] timeSeries, int duration)
    {
        if (timeSeries.Length == 0) return 0;
        if (timeSeries.Length == 1) return duration;
        var k = 0;
        for (var i = 0; i < timeSeries.Length - 1; i++)
        {
            if (timeSeries[i] + duration <= timeSeries[i + 1])
            {
                k += duration;
            }
            else
            {
                k += timeSeries[i + 1] - timeSeries[i];
            }
        }
        return k + duration;
    }
}

public class Q495_TeemoAttackingTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1, 4}, 2, 4],
        [new int[] {1, 2}, 2, 3],
        [new int[] {10, 15}, 4, 8],
        [new int[] {10, 15}, 8, 13],
    ];
}

public class Q495_TeemoAttackingTests
{
    [Theory]
    [ClassData(typeof(Q495_TeemoAttackingTestData))]
    public void OfficialTestCases(int[] timeSeries, int duration, int expected)
    {
        var sut = new Q495_TeemoAttacking();
        var actual = sut.FindPoisonedDuration(timeSeries, duration);
        Assert.Equal(expected, actual);
    }
}