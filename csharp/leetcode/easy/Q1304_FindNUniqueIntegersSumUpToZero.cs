class Q1304_FindNUniqueIntegersSumUpToZero
{
    public int[] SumZero(int n)
    {
        return [];
    }
}
class Q1304_FindNUniqueIntegersSumUpToZeroTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [5, new int[]{-7,-1,1,3,4}],
        [3, new int[]{-1,0,1}],
        [1, new int[]{0}],
    ];
}
public class Q1304_FindNUniqueIntegersSumUpToZeroTests
{
    [Theory]
    [ClassData(typeof(Q1304_FindNUniqueIntegersSumUpToZeroTestData))]
    public void OfficialTestCases(int input, int[] expected)
    {
        var sut = new Q1304_FindNUniqueIntegersSumUpToZero();
        var actual = sut.SumZero(input);
        var distinctCount = actual.Distinct().Count();
        var actualSum = actual.Sum();

        Assert.Equal(input, distinctCount);
        Assert.Equal(expected.Distinct().Count(), distinctCount);
        Assert.Equal(0, actualSum);
        Assert.Equal(expected.Sum(), actualSum);
    }
}