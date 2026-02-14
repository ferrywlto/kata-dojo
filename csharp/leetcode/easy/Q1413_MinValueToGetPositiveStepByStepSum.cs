
class Q1413_MinValueToGetPositiveStepByStepSum
{
    // TC: O(n), n is the size of nums
    // SC: O(1), no space used in operations
    public int MinStartValue(int[] nums)
    {
        var min = 0;
        var sum = 0;
        foreach (var n in nums)
        {
            sum += n;
            if (sum < min) min = sum;
        }
        return Math.Abs(min) + 1;
    }
}
class Q1413_MinValueToGetPositiveStepByStepSumTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {-3,2,-3,4,2}, 5],
        [new int[] {1,2}, 1],
        [new int[] {1,-2,-3}, 5],
    ];
}
public class Q1413_MinValueToGetPositiveStepByStepSumTests
{
    [Theory]
    [ClassData(typeof(Q1413_MinValueToGetPositiveStepByStepSumTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1413_MinValueToGetPositiveStepByStepSum();
        var actual = sut.MinStartValue(input);
        Assert.Equal(expected, actual);
    }
}
