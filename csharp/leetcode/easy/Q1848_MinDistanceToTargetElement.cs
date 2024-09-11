class Q1848_MinDistanceToTargetElement
{
    public int GetMinDistance(int[] nums, int target, int start)
    {
        return 0;
    }
}
class Q1848_MinDistanceToTargetElementTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,3,4,5}, 5, 3, 1],
        [new int[] {1}, 1, 0, 0],
        [new int[] {1,1,1,1,1,1,1,1,1,1}, 1, 0, 0],
    ];
}
public class Q1848_MinDistanceToTargetElementTests
{
    [Theory]
    [ClassData(typeof(Q1848_MinDistanceToTargetElementTestData))]
    public void OfficialTestCases(int[] input, int target, int start, int expected)
    {
        var sut = new Q1848_MinDistanceToTargetElement();
        var actual = sut.GetMinDistance(input, target, start);
        Assert.Equal(expected, actual);
    }
}