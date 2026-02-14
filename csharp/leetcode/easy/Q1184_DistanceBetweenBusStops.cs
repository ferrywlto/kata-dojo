class Q1184_DistanceBetweenBusStops
{
    // TC: O(n), need to traverse each element once due to checking both ways
    // SC: O(1)
    public int DistanceBetweenBusStops(int[] distance, int start, int destination)
    {
        if (start == destination) return 0;
        // go clockwise
        var distanceCW = 0;
        for (var i = start; i != destination; i++)
        {
            distanceCW += distance[i];
            if (i == distance.Length - 1) i = -1;
        }
        // go anti-clockwise
        var distanceACW = 0;
        for (var j = start; j != destination; j--)
        {
            if (j == 0) j = distance.Length;
            distanceACW += distance[j - 1];
        }
        return Math.Min(distanceCW, distanceACW);
    }
}
class Q1184_DistanceBetweenBusStopsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,3,4}, 0, 1, 1],
        [new int[]{1,2,3,4}, 1, 0, 1],
        [new int[]{1,2,3,4}, 0, 2, 3],
        [new int[]{1,2,3,4}, 2, 0, 3],
        [new int[]{1,2,3,4}, 0, 3, 4],
        [new int[]{1,2,3,4}, 3, 0, 4],
        // [new int[]{5,7,6,1,1,2,5,4,9,1}, 3, 0, 4],
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
