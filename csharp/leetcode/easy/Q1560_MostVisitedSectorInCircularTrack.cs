
class Q1560_MostVisitedSectorInCircularTrack
{
    public IList<int> MostVisited(int n, int[] rounds) 
    {
        return [];        
    }
}
class Q1560_MostVisitedSectorInCircularTrackTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [4, new int[] {1,3,1,2}, new List<int> {1,2}],
        [2, new int[] {2,1,2,1,2,1,2,1,2}, new List<int> {2}],
        [7, new int[] {1,3,5,7}, new List<int> {1,2,3,4,5,6,7}],
    ];
}
public class Q1560_MostVisitedSectorInCircularTrackTests
{
    [Theory]
    [ClassData(typeof(Q1560_MostVisitedSectorInCircularTrackTestData))]
    public void OfficialTestCases(int n, int[] sectors, List<int> expected)
    {
        var sut = new Q1560_MostVisitedSectorInCircularTrack();
        var actual = sut.MostVisited(n, sectors);
        Assert.Equal(expected, actual);
    }
}