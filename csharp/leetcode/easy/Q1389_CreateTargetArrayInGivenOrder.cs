class Q1389_CreateTargetArrayInGivenOrder
{
    public int[] CreateTargetArray(int[] nums, int[] index) 
    {
        return [];
    } 
}
class Q1389_CreateTargetArrayInGivenOrderTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {0,1,2,3,4}, new int[] {0,1,2,2,1}, new int[] {0,4,1,3,2}],
        [new int[] {1,2,3,4,0}, new int[] {0,1,2,3,0}, new int[] {0,1,2,3,4}],
        [new int[] {1}, new int[] {0}, new int[] {1}],
    ];
}
public class Q1389_CreateTargetArrayInGivenOrderTests
{
    [Theory]
    [ClassData(typeof(Q1389_CreateTargetArrayInGivenOrderTestData))]
    public void OfficialTestCases(int[] input, int[] index, int[] expected)
    {
        var sut = new Q1389_CreateTargetArrayInGivenOrder();
        var actual = sut.CreateTargetArray(input, index);
        Assert.Equal(expected, actual);
    }
}