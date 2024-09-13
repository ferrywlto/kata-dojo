class Q1863_SumOfAllSubsetXORTotal
{
    public int SubsetXORSum(int[] nums)
    {
        return 0;
    }
}
class Q1863_SumOfAllSubsetXORTotalTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,3}, 6],
        [new int[] {5,1,6}, 28],
        [new int[] {3,4,5,6,7,8}, 480],
    ];
}
public class Q1863_SumOfAllSubsetXORTotalTests
{
    [Theory]
    [ClassData(typeof(Q1863_SumOfAllSubsetXORTotalTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1863_SumOfAllSubsetXORTotal();
        var actual = sut.SubsetXORSum(input);
        Assert.Equal(expected, actual);
    }
}