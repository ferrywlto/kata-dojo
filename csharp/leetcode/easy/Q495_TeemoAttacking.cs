
namespace dojo.leetcode;

public class Q495_TeemoAttacking
{
    public int FindPoisonedDuration(int[] timeSeries, int duration)
    {
        return 0;
    }
}

public class Q495_TeemoAttackingTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1, 4}, 2, 4],
        [new int[] {1, 2}, 2, 3]
    ];
}

public class Q495_TeemoAttackingTests
{
    [Theory]
    [ClassData(typeof(Q495_TeemoAttackingTestData))]
    public void Test(int[] timeSeries, int duration, int expected)
    {
        var sut = new Q495_TeemoAttacking();
        var actual = sut.FindPoisonedDuration(timeSeries, duration);
        Assert.Equal(expected, actual);
    }
}