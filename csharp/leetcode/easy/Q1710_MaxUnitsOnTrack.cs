
class Q1710_MaxUnitsOnTrack
{
    public int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        return 0;
    }
}
class Q1710_MaxUnitsOnTrackTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[][]{[1,3],[2,2],[3,1]}, 4, 8],
        [new int[][]{[5,10],[2,5],[4,7],[3,9]}, 10, 91],
    ];
}
public class Q1710_MaxUnitsOnTrackTests
{
    [Theory]
    [ClassData(typeof(Q1710_MaxUnitsOnTrackTestData))]
    public void OfficialTestCases(int[][] input, int size, int expected)
    {
        var sut = new Q1710_MaxUnitsOnTrack();
        var actual = sut.MaximumUnits(input, size);
        Assert.Equal(expected, actual);
    }
}