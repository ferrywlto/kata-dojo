
class Q1732_FindHighestAltitude
{
    public int LargestAltitude(int[] gain)
    {
        return 0;
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
