class Q1588_SumOfAllOddLengthSubarrays
{
    public int SumOddLengthSubarrays(int[] arr)
    {
        return 0;
    }
}
class Q1588_SumOfAllOddLengthSubarraysTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,4,2,5,3}, 58],
        [new int[] {1,2}, 3],
        [new int[] {10,11,12}, 66],
    ];
}
public class Q1588_SumOfAllOddLengthSubarraysTests
{
    [Theory]
    [ClassData(typeof(Q1588_SumOfAllOddLengthSubarraysTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1588_SumOfAllOddLengthSubarrays();
        var actual = sut.SumOddLengthSubarrays(input);
        Assert.Equal(expected, actual);
    }
}