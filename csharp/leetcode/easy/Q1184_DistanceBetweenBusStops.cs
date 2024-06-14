class Q1184_DistanceBetweenBusStops
{
    public int DistanceBetweenBusStops(int[] distance, int start, int destination)
    {
        return 0;
    }
}
class Q1184_DistanceBetweenBusStopsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,3,4}, 0, 1, 1],
        [new int[]{1,2,3,4}, 0, 2, 3],
        [new int[]{1,2,3,4}, 0, 3, 4],
    ];
}
public class Q1184_DistanceBetweenBusStopsTests
{
    [Theory]
    [ClassData(typeof(Q1184_DistanceBetweenBusStopsTestData))]
    public void OfficialTestCases(int[] distance, int start, int destination, int expected)
    {
        var sut = new Q1184_DistanceBetweenBusStops();
        var actual = sut.DistanceBetweenBusStops(distance, start, destination);
        Assert.Equal(expected, actual);
    }
}
