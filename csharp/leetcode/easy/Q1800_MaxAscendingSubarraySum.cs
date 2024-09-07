class Q1800_MaxAscendingSubarraySum
{
    public int MaxAscendingSum(int[] nums)
    {
        return 0;
    }
}
class Q1800_MaxAscendingSubarraySumTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {10,20,30,5,10,50}, 65],
        [new int[] {10,20,30,40,50}, 150],
        [new int[] {12,17,15,13,10,11,12}, 33],
    ];
}
public class Q1800_MaxAscendingSubarraySumTests
{
    [Theory]
    [ClassData(typeof(Q1800_MaxAscendingSubarraySumTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1800_MaxAscendingSubarraySum();
        var actual = sut.MaxAscendingSum(input);
        Assert.Equal(expected, actual);
    }
}