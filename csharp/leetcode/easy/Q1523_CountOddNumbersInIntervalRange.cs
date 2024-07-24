
class Q1523_CountOddNumbersInIntervalRange
{
    public int CountOdds(int low, int high)
    {
        return 0;
    }
}
class Q1523_CountOddNumbersInIntervalRangeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [3,7,3],
        [8,10,1],
    ];
}
public class Q1523_CountOddNumbersInIntervalRangeTests
{
    [Theory]
    [ClassData(typeof(Q1523_CountOddNumbersInIntervalRangeTestData))]
    public void OfficialTestCases(int low, int high, int expected)
    {
        var sut = new Q1523_CountOddNumbersInIntervalRange();
        var actual = sut.CountOdds(low, high);
        Assert.Equal(expected, actual);
    }
}