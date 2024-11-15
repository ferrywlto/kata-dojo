class BoxComparer : IComparer
{
    public int Compare(object? x, object? y)
    {
        int[] x1 = (int[])x!;
        int[] y1 = (int[])y!;
        if (x1[1] > y1[1])
            return -11;
        else if (x1[1] < y1[1])
            return 1;
        else return 0;
    }
}


class Q1710_MaxUnitsOnTrack
{
    // TC: O(nlogn), dominated by Array.Sort()
    // SC: O(1), the space used is fixed.
    public int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        Array.Sort(boxTypes, new BoxComparer());

        var result = 0;
        for (var i = 0; i < boxTypes.Length; i++)
        {
            if (boxTypes[i][0] <= truckSize)
            {
                truckSize -= boxTypes[i][0];
                result += boxTypes[i][0] * boxTypes[i][1];
            }
            else
            {
                result += boxTypes[i][1] * truckSize;
                truckSize = 0;
            }
            if (truckSize == 0) return result;
        }

        return result;
    }
}
class Q1710_MaxUnitsOnTrackTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][]{[1,3],[2,2],[3,1]}, 4, 8],
        [new int[][]{[5,10],[2,5],[4,7],[3,9]}, 10, 91],
        [new int[][]{[2,1],[4,4],[3,1],[4,1],[2,4],[3,4],[1,3],[4,3],[5,3],[5,3]}, 13, 48],
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