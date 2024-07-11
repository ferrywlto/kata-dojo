
class Q1413_MinValueToGetPositiveStepByStepSum
{
    public int MinStartValue(int[] nums) 
    {
        return 0;
    }
}
class Q1413_MinValueToGetPositiveStepByStepSumTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {-3,2,-3,4,2}, 5],
        [new int[] {1,2}, 1],
        [new int[] {1,-2,-3}, 1],
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