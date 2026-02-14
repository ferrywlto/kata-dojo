class Q1732_FindHighestAltitude
{
    // TC: O(n), where n is length of gain
    // SC: O(1), space used is fixed
    public int LargestAltitude(int[] gain)
    {
        var max = 0;
        var current = 0;
        foreach (var p in gain)
        {
            current += p;
            if (current > max) max = current;
        }
        return max;
    }
}
class Q1732_FindHighestAltitudeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {-5,1,5,0,-7}, 1],
        [new int[] {-4,-3,-2,-1,4,3,2}, 0],
    ];
}
public class Q1732_FindHighestAltitudeTests
{
    [Theory]
    [ClassData(typeof(Q1732_FindHighestAltitudeTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1732_FindHighestAltitude();
        var actual = sut.LargestAltitude(input);
        Assert.Equal(expected, actual);
    }
}
