
class Q1523_CountOddNumbersInIntervalRange
{
    // TC: O(1)
    // SC: O(1)
    public int CountOdds(int low, int high)
    {
        var temp = (high - low) / 2;
        return low % 2 == 0 && high % 2 == 0 ? temp : temp + 1;
    }
}
class Q1523_CountOddNumbersInIntervalRangeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [3,7,3],
        [8,10,1],
        [0,10,5],
        [0,8,4],
        [2,6,2],
        [1,11,6],
        [3,9,4],
        [5,9,3],
        [1,10,5],
        [1,8,4],
        [2,9,4],
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